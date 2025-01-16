using CodeDesignPlus.Net.Cache.Abstractions;

namespace Acme.Net.Microservice.Inventory.Application.Inventory.Queries.GetInventoryById;

public class GetInventoryByIdQueryHandler(IInventoryRepository repository, IMapper mapper, ICacheManager cacheManager) : IRequestHandler<GetInventoryByIdQuery, InventoryDto>
{
    public async Task<InventoryDto> Handle(GetInventoryByIdQuery request, CancellationToken cancellationToken)
    {
        ApplicationGuard.IsNull(request, Errors.InvalidRequest);

        var exists = await cacheManager.ExistsAsync(request.Id.ToString());

        if (exists)
            return await cacheManager.GetAsync<InventoryDto>(request.Id.ToString());

        var inventory = await repository.FindAsync<InventoryAggregate>(request.Id, cancellationToken);

        ApplicationGuard.IsNull(inventory, Errors.InventoryNotFound);

        await cacheManager.SetAsync(request.Id.ToString(), mapper.Map<InventoryDto>(inventory));

        return mapper.Map<InventoryDto>(inventory);
    }
}
