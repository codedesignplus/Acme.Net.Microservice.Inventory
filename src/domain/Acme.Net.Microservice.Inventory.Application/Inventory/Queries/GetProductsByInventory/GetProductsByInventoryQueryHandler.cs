using CodeDesignPlus.Net.Cache.Abstractions;

namespace Acme.Net.Microservice.Inventory.Application.Inventory.Queries.GetProductsByInventory;

public class GetProductsByInventoryQueryHandler(IInventoryRepository repository, IMapper mapper, ICacheManager cacheManager) : IRequestHandler<GetProductsByInventoryQuery, List<ProductDto>>
{
    public async Task<List<ProductDto>> Handle(GetProductsByInventoryQuery request, CancellationToken cancellationToken)
    {
        ApplicationGuard.IsNull(request, Errors.InvalidRequest);

        var exists = await cacheManager.ExistsAsync(request.Id.ToString());

        if (exists)
            return await cacheManager.GetAsync<List<ProductDto>>(request.Id.ToString());

        var inventory = await repository.FindAsync<InventoryAggregate>(request.Id, cancellationToken);

        ApplicationGuard.IsNull(inventory, Errors.InventoryNotFound);

        await cacheManager.SetAsync(request.Id.ToString(), mapper.Map<List<InventoryDto>>(inventory.Products));

        return mapper.Map<List<ProductDto>>(inventory);
    }
}
