namespace Acme.Net.Microservice.Inventory.AsyncWorker.DomainEvents;

[EventKey<ProductAggregate>(1, "ProductUpdatedDomainEvent")]
public class ProductUpdatedDomainEvent(
    Guid aggregateId,
    string name,
    long price,
    ushort quantity,
    Guid updatedBy,
    Guid? eventId = null,
    DateTime? occurredAt = null,
    Dictionary<string, object>? metadata = null
) : DomainEvent(aggregateId, eventId, occurredAt, metadata)
{
    public string Name { get; } = name;
    public long Price { get; } = price;
    public ushort Quantity { get; } = quantity;
    public Guid UpdatedBy { get; } = updatedBy;


    public static ProductUpdatedDomainEvent Create(Guid aggregateId, string name, long price, ushort quantity, Guid updatedBy)
    {
        return new ProductUpdatedDomainEvent(aggregateId, name, price, quantity, updatedBy);
    }
}
