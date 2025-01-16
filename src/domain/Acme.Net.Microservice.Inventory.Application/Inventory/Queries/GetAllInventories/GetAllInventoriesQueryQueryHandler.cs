namespace Acme.Net.Microservice.Inventory.Application.Inventory.Queries.GetAllInventories;

public class GetAllInventoriesQueryQueryHandler(IInventoryRepository repository, IMapper mapper) : IRequestHandler<GetAllInventoriesQuery, List<InventoryDto>>
{
    public async Task<List<InventoryDto>> Handle(GetAllInventoriesQuery request, CancellationToken cancellationToken)
    {
        ApplicationGuard.IsNull(request, Errors.InvalidRequest);

        var inventories = await repository.MatchingAsync<InventoryAggregate>(request.Criteria, cancellationToken);

        return mapper.Map<List<InventoryDto>>(inventories);
    }
}
