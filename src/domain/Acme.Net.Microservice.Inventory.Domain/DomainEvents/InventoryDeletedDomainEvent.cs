
namespace Acme.Net.Microservice.Inventory.Domain.DomainEvents;

[EventKey<InventoryAggregate>(1, "InventoryDeletedDomainEvent")]
public class InventoryDeletedDomainEvent(
    Guid aggregateId,
    string name,
    string code,
    List<ProductEntity> products,
    Guid tenant,
    bool isActive,
    Guid createdBy,
    long createdAt,
    Guid? updatedBy,
    long? updatedAt,
    Guid? eventId = null,
    DateTime? occurredAt = null,
    Dictionary<string, object>? metadata = null
) : DomainEvent(aggregateId, eventId, occurredAt, metadata)
{
    public string Name { get; private set; } = name;
    public string Code { get; private set; } = code;
    public List<ProductEntity> Products { get; private set; } = products;
    public Guid Tenant { get; private set; } = tenant;
    public bool IsActive { get; private set; } = isActive;
    public Guid CreatedBy { get; private set; } = createdBy;
    public long CreatedAt { get; private set; } = createdAt;
    public Guid? UpdatedBy { get; private set; } = updatedBy;
    public long? UpdatedAt { get; private set; } = updatedAt;

    public static InventoryDeletedDomainEvent Create(
        Guid aggregateId,
        string name,
        string code,
        List<ProductEntity> products,
        Guid tenant,
        bool isActive,
        Guid createdBy,
        long createdAt,
        Guid? updatedBy,
        long? updatedAt)
    {
        return new InventoryDeletedDomainEvent(
            aggregateId,
            name,
            code,
            products,
            tenant,
            isActive, createdBy,
            createdAt,
            updatedBy,
            updatedAt);
    }
}
