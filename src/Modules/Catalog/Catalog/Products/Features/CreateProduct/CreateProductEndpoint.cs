namespace Catalog.Products.Features.CreateProduct;

public record CreateProductRequest(ProductDto Product);
public record CreateProductRespond(Guid Id);

public class CreateProductEndpoint : ICarterModule {
    public void AddRoutes(IEndpointRouteBuilder app) {
        app.MapPost("/products", async (CreateProductRequest request, ISender sender) => {
            var command = request.Adapt<CreateProductCommand>();
            var result = await sender.Send(command);

            var respond = result.Adapt<CreateProductRespond>();
            return Results.Created($"/products/{respond.Id}", respond);
        })
        .WithName("CreateProduct")
        .Produces<CreateProductRespond>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Create Product")
        .WithDescription("Create Product");
    }
}