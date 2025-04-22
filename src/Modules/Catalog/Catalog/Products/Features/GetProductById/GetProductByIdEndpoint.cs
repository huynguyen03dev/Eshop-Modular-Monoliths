﻿namespace Catalog.Products.Features.GetProductById;

//public record GetProductByIdRequest(Guid Id);

public record GetProductByIdRespond(ProductDto Product);

public class GetProductByIdEndpoint : ICarterModule {
    public void AddRoutes(IEndpointRouteBuilder app) {
        app.MapGet("/products/{id}", async (Guid id, ISender sender) => {
            var result = await sender.Send(new GetProductByIdQuery(id));

            var respond = result.Adapt<GetProductByIdRespond>();

            return Results.Ok(respond);
        })
        .WithName("GetProductById")
        .Produces<GetProductByIdRespond>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Get Product By Id")
        .WithDescription("Get Product By Id");
    }
}