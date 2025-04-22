using Shared.Pagination;

namespace Catalog.Products.Features.GetProducts;

//public record GetProductsRequest(ProductDto Product);

public record GetProductsRespond(PaginatedResult<ProductDto> Products);

public class GetProductsEndpoint : ICarterModule {
    public void AddRoutes(IEndpointRouteBuilder app) {
        app.MapGet("/products", async ([AsParameters] PaginationRequest request, ISender sender) => {
            var result = await sender.Send(new GetProductsQuery(request));
            
            var respond = result.Adapt<GetProductsRespond>();  

            return Results.Ok(respond);
        })
        .WithName("GetProducts")
        .Produces<GetProductsRespond>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get Products")
        .WithDescription("Get Products");
    }
}