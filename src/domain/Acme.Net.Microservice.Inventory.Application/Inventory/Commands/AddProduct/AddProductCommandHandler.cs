namespace Acme.Net.Microservice.Inventory.Application.Inventory.Commands.AddProduct;

public class AddProductCommandHandler(IInventoryRepository repository, IUserContext user, IPubSub pubSub) : IRequestHandler<AddProductCommand>
{
    public async Task Handle(AddProductCommand request, CancellationToken cancellationToken)
    {
        ApplicationGuard.IsNull(request, Errors.InvalidRequest);

        var inventory = await repository.FindAsync<InventoryAggregate>(request.Id, cancellationToken);

        ApplicationGuard.IsNull(inventory, Errors.InventoryNotFound);

        inventory.AddProduct(new ProductEntity()
        {
            Id = request.IdProduct,
            Name = request.Name,
            Quantity = request.Quantity,
            Price = request.Price
        }, user.IdUser);

        await repository.UpdateAsync(inventory, cancellationToken);

        await pubSub.PublishAsync(inventory.GetAndClearEvents(), cancellationToken);
    }
}