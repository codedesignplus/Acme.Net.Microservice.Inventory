namespace Acme.Net.Microservice.Inventory.Domain.Repositories;

public interface IProductRepository : IRepositoryBase
{

    Task CreateProductAsync(ProductAggregate Product, CancellationToken cancellationToken);
    Task UpdateProductAsync(ProductAggregate Product, CancellationToken cancellationToken);
    Task<bool> ProductExistsAsync(Guid id, CancellationToken cancellationToken);
}