namespace Acme.Net.Microservice.Inventory.Application.Inventory.DataTransferObjects;

public class InventoryDto: IDtoBase
{
    public required Guid Id { get; set; }
}