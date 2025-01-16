namespace Acme.Net.Microservice.Inventory.AsyncWorker.DomainEvents;

[EventKey<ProductAggregate>(1, "ProductCreatedDomainEvent")]
public class ProductCreatedDomainEvent(
    Guid aggregateId,
    string name,
    long price,
    ushort quantity,
    Guid createdBy,
    Guid tenant,
    Guid? eventId = null,
    DateTime? occurredAt = null,
    Dictionary<string, object>? metadata = null
) : DomainEvent(aggregateId, eventId, occurredAt, metadata)
{
    public string Name { get; } = name;
    public long Price { get; } = price;
    public ushort Quantity { get; } = quantity;
    public Guid CreatedBy { get; } = createdBy;
    public Guid Tenant { get; } = tenant;


    public static ProductCreatedDomainEvent Create(Guid aggregateId, string name, long price, ushort quantity, Guid createdBy, Guid tenant)
    {
        return new ProductCreatedDomainEvent(aggregateId, name, price, quantity, createdBy, tenant);
    }
}
