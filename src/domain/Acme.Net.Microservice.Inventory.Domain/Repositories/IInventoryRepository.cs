namespace Acme.Net.Microservice.Inventory.Domain.Repositories;

public interface IInventoryRepository : IRepositoryBase
{
    Task CreateInventoryAsync(InventoryAggregate Inventory, CancellationToken cancellationToken);
    Task UpdateInventoryAsync(InventoryAggregate Inventory, CancellationToken cancellationToken);
    Task DeleteInventoryAsync(Guid id, CancellationToken cancellationToken);
    Task<bool> InventoryExistsAsync(Guid id, CancellationToken cancellationToken);
}