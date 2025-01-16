namespace Acme.Net.Microservice.Inventory.Application.Inventory.Commands.UpdateProduct;

public class UpdateProductCommandHandler(IInventoryRepository repository, IUserContext user, IPubSub pubSub) : IRequestHandler<UpdateProductCommand>
{
    public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        ApplicationGuard.IsNull(request, Errors.InvalidRequest);

        var inventory = await repository.FindAsync<InventoryAggregate>(request.Id, cancellationToken);

        ApplicationGuard.IsNull(inventory, Errors.InventoryNotFound);

        inventory.UpdateProduct(new ProductEntity()
        {
            Id = request.IdProduct,
            Name = request.Name,
            Price = request.Price,
            Quantity = request.Quantity
        }, user.IdUser);

        await repository.UpdateAsync(inventory, cancellationToken);

        await pubSub.PublishAsync(inventory.GetAndClearEvents(), cancellationToken);
    }
}