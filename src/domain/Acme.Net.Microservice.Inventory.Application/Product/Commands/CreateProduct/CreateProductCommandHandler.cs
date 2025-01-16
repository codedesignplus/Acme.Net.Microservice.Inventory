namespace Acme.Net.Microservice.Inventory.Application.Product.Commands.CreateProduct;

public class CreateProductCommandHandler(IProductRepository repository) : IRequestHandler<CreateProductCommand>
{
    public async Task Handle(CreateProductCommand request, CancellationToken cancellationToken)
    {
        ApplicationGuard.IsNull(request, Errors.InvalidRequest);

        var exist = await repository.ProductExistsAsync(request.Id, cancellationToken);

        ApplicationGuard.IsTrue(exist, Errors.ProductAlreadyExists);

        var product = ProductAggregate.Create(request.Id, request.Name, request.Price, request.Quantity, request.Tenant, request.CreatedBy);

        ApplicationGuard.IsNotNull(product, Errors.ProductAlreadyExists);

        await repository.CreateProductAsync(product, cancellationToken);
    }
}