namespace Acme.Net.Microservice.Inventory.Application.Inventory.Commands.DeleteInvetory;

public class DeleteInvetoryCommandHandler(IInventoryRepository repository, IUserContext user, IPubSub pubSub) : IRequestHandler<DeleteInvetoryCommand>
{
    public async Task Handle(DeleteInvetoryCommand request, CancellationToken cancellationToken)
    {        
        ApplicationGuard.IsNull(request, Errors.InvalidRequest);

        var inventory = await repository.FindAsync<InventoryAggregate>(request.Id, cancellationToken);

        ApplicationGuard.IsNull(inventory, Errors.InventoryNotFound);

        inventory.Delete(user.IdUser);

        await repository.UpdateAsync(inventory, cancellationToken);

        await pubSub.PublishAsync(inventory.GetAndClearEvents(), cancellationToken);
    }
}