﻿namespace Catalog.Products.Features.GetProductByCategory;

//public record GetProductByCategoryRequest(string Category);

public record GetProductByCategoryResponse(IEnumerable<ProductDto> Products);

public class GetProductByCategoryEndpoint : ICarterModule {
    public void AddRoutes(IEndpointRouteBuilder app) {
        app.MapGet("/products/category/{category}", async (string category, ISender sender) => {
            var result = await sender.Send(new GetProductByCategoryQuery(category));

            var respond = result.Adapt<GetProductByCategoryResponse>();

            return Results.Ok(respond);
        })
        .WithName("GetProductByCategory")
        .Produces<GetProductByCategoryResponse>(StatusCodes.Status200OK)
        .Produces(StatusCodes.Status400BadRequest)
        .WithTags("Get Product By Category")
        .WithDescription("Get Product By Category");
    }
}