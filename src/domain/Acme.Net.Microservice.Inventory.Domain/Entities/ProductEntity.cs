namespace Acme.Net.Microservice.Inventory.Domain.Entities;

public class ProductEntity : IEntityBase
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public long Price { get; set; }
    public ushort Quantity { get; set; }
}
