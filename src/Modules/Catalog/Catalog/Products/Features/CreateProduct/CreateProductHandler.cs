namespace Catalog.Products.Features.CreateProduct;

public record CreateProductCommand(ProductDto Product)
    : ICommand<CreateProductResult>;

public record CreateProductResult(Guid Id);

public class CreateProductValidator : AbstractValidator<CreateProductCommand> {
    public CreateProductValidator() {
        RuleFor(x => x.Product.Name).NotEmpty().WithMessage("Product name is required.");
        RuleFor(x => x.Product.Category).NotEmpty().WithMessage("Product category is required.");
        RuleFor(x => x.Product.ImageFile).NotEmpty().WithMessage("Product image file is required.");
        RuleFor(x => x.Product.Price).GreaterThan(0).WithMessage("Product price must be greater than zero.");
    }
}

internal class CreateProductHandler
    (CatalogDbContext dbContext)
    : ICommandHandler<CreateProductCommand, CreateProductResult> {
    public async Task<CreateProductResult> Handle(CreateProductCommand command, CancellationToken cancellationToken) {
        // Create Product entity from command object
        // Save to database
        // Return result

        var product = CreateNewProduct(command.Product);

        dbContext.Products.Add(product);
        await dbContext.SaveChangesAsync(cancellationToken);

        return new CreateProductResult(product.Id);
    }

    private Product CreateNewProduct(ProductDto productDto) {
        var product = Product.Create(
            Guid.NewGuid(),
            productDto.Name,
            productDto.Category,
            productDto.Description,
            productDto.ImageFile,
            productDto.Price
        );

        return product;
    }
}