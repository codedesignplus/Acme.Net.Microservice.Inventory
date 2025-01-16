namespace Acme.Net.Microservice.Inventory.Domain.DomainEvents;

[EventKey<InventoryAggregate>(1, "InventoryCreatedDomainEvent")]
public class InventoryCreatedDomainEvent(
    Guid aggregateId,
    string name,
    string code,
    Guid tenant,
    bool isActive,
    Guid createdBy,
    long createdAt,
    Guid? eventId = null,
    DateTime? occurredAt = null,
    Dictionary<string, object>? metadata = null
) : DomainEvent(aggregateId, eventId, occurredAt, metadata)
{
    public string Name { get; private set; } = name;
    public string Code { get; private set; } = code;
    public Guid Tenant { get; private set; } = tenant;
    public bool IsActive { get; private set; } = isActive;
    public Guid CreatedBy { get; private set; } = createdBy;
    public long CreatedAt { get; private set; } = createdAt;

    public static InventoryCreatedDomainEvent Create(Guid aggregateId, string name, string code, Guid tenant, bool isActive, Guid createdBy, long createdAt)
    {
        return new InventoryCreatedDomainEvent(
            aggregateId,
            name,
            code,
            tenant,
            isActive, createdBy,
            createdAt);
    }
}
