namespace Acme.Net.Microservice.Inventory.Application.Inventory.Commands.CreateInventory;

public class CreateInventoryCommandHandler(IInventoryRepository repository, IUserContext user, IPubSub pubSub) : IRequestHandler<CreateInventoryCommand>
{
    public async Task Handle(CreateInventoryCommand request, CancellationToken cancellationToken)
    {
        ApplicationGuard.IsNull(request, Errors.InvalidRequest);

        var exist = await repository.InventoryExistsAsync(request.Id, cancellationToken);

        ApplicationGuard.IsTrue(exist, Errors.InventoryAlreadyExists);

        var inventory = InventoryAggregate.Create(request.Id, request.Name, request.Code, user.Tenant, user.IdUser);

        await repository.CreateAsync(inventory, cancellationToken);

        await pubSub.PublishAsync(inventory.GetAndClearEvents(), cancellationToken);
    }
}