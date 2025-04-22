namespace Catalog.Products.EventHandlers;

public class ProductPriceChangedEventHandler(ILogger<ProductPriceChangedEventHandler> logger)
    : INotificationHandler<ProductPriceChangedEvent> {
    public Task Handle(ProductPriceChangedEvent notification, CancellationToken cancellationToken) {
        // TODO: publish product price changed integration event for update basket price
        logger.LogInformation("Domain Event handled: {Domain Event}", notification.GetType().Name);
        return Task.CompletedTask;
    }
}