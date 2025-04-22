namespace Catalog.Products.Features.UpdateProduct;

public record UpdateProductRequest(ProductDto Product);
public record UpdateProductRespond(bool IsSuccess);

public class UpdateProductEndpoint : ICarterModule {
    public void AddRoutes(IEndpointRouteBuilder app) {
        app.MapPut("/products", async (UpdateProductRequest request, ISender sender) => {
            var command = request.Adapt<UpdateProductCommand>();

            var result = await sender.Send(command);

            var respond = result.Adapt<UpdateProductRespond>();

            return Results.Ok(respond);
        })
        .WithName("UpdateProduct")
        .Produces<UpdateProductRespond>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Update Product")
        .WithDescription("Update Product");
    }
}