namespace Acme.Net.Microservice.Inventory.Application.Inventory.DataTransferObjects;

public class ProductDto: IDtoBase
{
    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public long Price { get; set; }
    public ushort Quantity { get; set; }
}
