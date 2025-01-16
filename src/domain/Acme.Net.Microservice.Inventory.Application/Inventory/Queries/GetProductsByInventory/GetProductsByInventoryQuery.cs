namespace Acme.Net.Microservice.Inventory.Application.Inventory.Queries.GetProductsByInventory;

public record GetProductsByInventoryQuery(Guid Id) : IRequest<List<ProductDto>>;

