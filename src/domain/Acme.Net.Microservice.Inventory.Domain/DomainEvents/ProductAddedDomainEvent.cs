namespace Acme.Net.Microservice.Inventory.Domain.DomainEvents;

[EventKey<InventoryAggregate>(1, "ProductAddedDomainEvent")]
public class ProductAddedDomainEvent(
    Guid aggregateId,
    ProductEntity product,
    Guid? eventId = null,
    DateTime? occurredAt = null,
    Dictionary<string, object>? metadata = null
) : DomainEvent(aggregateId, eventId, occurredAt, metadata)
{

    public ProductEntity Product { get; private set; } = product;

    public static ProductAddedDomainEvent Create(Guid aggregateId, ProductEntity product)
    {
        return new ProductAddedDomainEvent(aggregateId, product);
    }
}
