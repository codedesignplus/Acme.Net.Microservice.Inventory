namespace Acme.Net.Microservice.Inventory.Domain.DomainEvents;

[EventKey<InventoryAggregate>(1, "ProductUpdatedDomainEvent")]
public class ProductUpdatedDomainEvent(
    Guid aggregateId,
    ProductEntity product,
    Guid? eventId = null,
    DateTime? occurredAt = null,
    Dictionary<string, object>? metadata = null
) : DomainEvent(aggregateId, eventId, occurredAt, metadata)
{

    public ProductEntity Product { get; private set; } = product;

    public static ProductUpdatedDomainEvent Create(Guid aggregateId, ProductEntity product)
    {
        return new ProductUpdatedDomainEvent(aggregateId, product);
    }
}
