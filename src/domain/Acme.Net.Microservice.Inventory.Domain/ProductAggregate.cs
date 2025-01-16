namespace Acme.Net.Microservice.Inventory.Domain;

public class ProductAggregate(Guid id) : AggregateRoot(id)
{    
    public string Name { get; set; } = string.Empty;
    public long Price { get; set; }
    public ushort Quantity { get; set; }

    public ProductAggregate(Guid id, string name, long price, ushort quantity, Guid tenant, Guid createdBy) : this(id)
    {
        Name = name;
        Price = price;
        Quantity = quantity;
        Tenant = tenant;
        CreatedBy = createdBy;
    }

    public static ProductAggregate Create(Guid id, string name, long price, ushort quantity, Guid tenant, Guid createdBy)
    {
        return new ProductAggregate(id, name, price, quantity, tenant, createdBy);
    }

    public void Update(string name, long price, ushort quantity, Guid updatedBy)
    {
        Name = name;
        Price = price;
        Quantity = quantity;
        UpdatedBy = updatedBy;
    }
}
