using CodeDesignPlus.Net.Core.Abstractions.Models.Criteria;

namespace Acme.Net.Microservice.Inventory.Application.Inventory.Queries.GetAllInventories;

public record GetAllInventoriesQuery(Criteria Criteria) : IRequest<List<InventoryDto>>;

