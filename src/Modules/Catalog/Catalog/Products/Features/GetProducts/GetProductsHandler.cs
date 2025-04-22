using Shared.Pagination;

namespace Catalog.Products.Features.GetProducts;
public record GetProductsQuery(PaginationRequest request)
    : IQuery<GetProductsResult>;

public record GetProductsResult(PaginatedResult<ProductDto> Products);

public class GetProductsHandler(CatalogDbContext dbContext)
    : IQueryHandler<GetProductsQuery, GetProductsResult> {
    public async Task<GetProductsResult> Handle(GetProductsQuery query, CancellationToken cancellationToken) {
        var pageIndex = query.request.pageIndex;
        var pageSize = query.request.pageSize;

        var totalCount = await dbContext.Products.LongCountAsync(cancellationToken);



        var products = await dbContext.Products
            .AsNoTracking()
            .OrderBy(p => p.Name)
            .Skip(pageSize * pageIndex)
            .Take(pageSize)
            .ToListAsync(cancellationToken);

        // Mapping product entity to ProdcutDto using Mapster
        var productDtos = products.Adapt<List<ProductDto>>();

        return new GetProductsResult(
            new PaginatedResult<ProductDto>(
                pageIndex,
                pageSize,
                totalCount,
                productDtos)
            );
    }
}