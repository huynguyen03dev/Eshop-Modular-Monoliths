
using Catalog.Products.Features.UpdateProduct;

namespace Catalog.Products.Features.DeleteProduct;

//public record DeleteProductRequest(Guid Id);

public record DeleteProductRespond(bool IsSuccess);

public class DeleteProductEndpoint : ICarterModule {
    public void AddRoutes(IEndpointRouteBuilder app) {
        app.MapDelete("/products/{id}", async (Guid id, ISender sender) => { 
            var result = await sender.Send(new DeleteProductCommand(id));

            var respond = result.Adapt<DeleteProductRespond>();

            return Results.Ok(respond);
        })
        .WithName("DeleteProduct")
        .Produces<UpdateProductRespond>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Delete Product")
        .WithDescription("Delete Product");
    }
}