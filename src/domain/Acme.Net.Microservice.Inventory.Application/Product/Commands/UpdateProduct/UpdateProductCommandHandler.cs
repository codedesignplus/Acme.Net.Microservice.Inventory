namespace Acme.Net.Microservice.Inventory.Application.Product.Commands.UpdateProduct;

public class UpdateProductCommandHandler(IProductRepository repository) : IRequestHandler<UpdateProductCommand>
{
    public async Task Handle(UpdateProductCommand request, CancellationToken cancellationToken)
    {
        ApplicationGuard.IsNull(request, Errors.InvalidRequest);

        var product = await repository.FindAsync<ProductAggregate>(request.Id, cancellationToken);

        ApplicationGuard.IsNull(product, Errors.ProductNotFound);

        product.Update(request.Name, request.Price, request.Quantity, request.UpdatedBy);

        await repository.UpdateProductAsync(product, cancellationToken);
    }
}