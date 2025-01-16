namespace Acme.Net.Microservice.Inventory.Infrastructure.Repositories;

public class ProductRepository(IServiceProvider serviceProvider, IOptions<MongoOptions> mongoOptions, ILogger<ProductRepository> logger) 
    : RepositoryBase(serviceProvider, mongoOptions, logger), IProductRepository
{
   
    public Task CreateProductAsync(ProductAggregate product, CancellationToken cancellationToken)
    {
        return base.CreateAsync<ProductAggregate>(product, cancellationToken);
    }

    public Task UpdateProductAsync(ProductAggregate product, CancellationToken cancellationToken)
    {
        return this.UpdateAsync(product, cancellationToken);
    }

    public Task<bool> ProductExistsAsync(Guid id, CancellationToken cancellationToken)
    {
        var filterId = Builders<ProductAggregate>.Filter.Eq(x => x.Id, id);

        return this.GetCollection<ProductAggregate>().Find(filterId).AnyAsync(cancellationToken);
    }
}