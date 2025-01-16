namespace Acme.Net.Microservice.Inventory.Application.Inventory.Commands.UpdateInventory;

public class UpdateInventoryCommandHandler(IInventoryRepository repository, IUserContext user, IPubSub pubSub) : IRequestHandler<UpdateInventoryCommand>
{
    public async Task Handle(UpdateInventoryCommand request, CancellationToken cancellationToken)
    {
        ApplicationGuard.IsNull(request, Errors.InvalidRequest);

        var inventory = await repository.FindAsync<InventoryAggregate>(request.Id, cancellationToken);

        ApplicationGuard.IsNull(inventory, Errors.InventoryNotFound);

        inventory.Update(request.Name, user.IdUser);

        await repository.UpdateAsync(inventory, cancellationToken);

        await pubSub.PublishAsync(inventory.GetAndClearEvents(), cancellationToken);
    }
}