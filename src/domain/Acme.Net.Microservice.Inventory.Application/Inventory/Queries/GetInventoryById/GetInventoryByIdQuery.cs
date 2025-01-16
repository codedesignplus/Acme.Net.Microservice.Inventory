namespace Acme.Net.Microservice.Inventory.Application.Inventory.Queries.GetInventoryById;

public record GetInventoryByIdQuery(Guid Id) : IRequest<InventoryDto>;

