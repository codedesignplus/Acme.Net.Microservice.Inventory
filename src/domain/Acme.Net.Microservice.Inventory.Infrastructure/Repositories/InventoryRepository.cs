namespace Acme.Net.Microservice.Inventory.Infrastructure.Repositories;

public class InventoryRepository(IServiceProvider serviceProvider, IOptions<MongoOptions> mongoOptions, ILogger<InventoryRepository> logger) 
    : RepositoryBase(serviceProvider, mongoOptions, logger), IInventoryRepository
{
    public Task CreateInventoryAsync(InventoryAggregate inventory, CancellationToken cancellationToken)
    {
        return base.CreateAsync<InventoryAggregate>(inventory, cancellationToken);
    }

    public Task UpdateInventoryAsync(InventoryAggregate inventory, CancellationToken cancellationToken)
    {
        return this.UpdateAsync(inventory, cancellationToken);
    }

    public Task DeleteInventoryAsync(Guid id, CancellationToken cancellationToken)
    {
        var filterId = Builders<InventoryAggregate>.Filter.Eq(x => x.Id, id);

        return this.DeleteAsync(filterId, cancellationToken);
    }

    public Task<bool> InventoryExistsAsync(Guid id, CancellationToken cancellationToken)
    {
        var filterId = Builders<InventoryAggregate>.Filter.Eq(x => x.Id, id);

        return this.GetCollection<InventoryAggregate>().Find(filterId).AnyAsync(cancellationToken);
    }
}