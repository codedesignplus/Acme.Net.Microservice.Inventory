namespace Acme.Net.Microservice.Inventory.Application.Inventory.Commands.RemoveProduct;

public class RemoveProductCommandHandler(IInventoryRepository repository, IUserContext user, IPubSub pubSub) : IRequestHandler<RemoveProductCommand>
{
    public async Task Handle(RemoveProductCommand request, CancellationToken cancellationToken)
    {
        ApplicationGuard.IsNull(request, Errors.InvalidRequest);

        var inventory = await repository.FindAsync<InventoryAggregate>(request.Id, cancellationToken);

        ApplicationGuard.IsNull(inventory, Errors.InventoryNotFound);

        inventory.RemovedProduct(request.IdProduct, user.IdUser);

        await repository.UpdateAsync(inventory, cancellationToken);

        await pubSub.PublishAsync(inventory.GetAndClearEvents(), cancellationToken);
    }
}