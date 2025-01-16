namespace Acme.Net.Microservice.Inventory.Application.Product.Commands.CreateProduct;

public record CreateProductCommand(Guid Id, string Name, long Price, ushort Quantity, Guid Tenant, Guid CreatedBy) : IRequest;

public class Validator : AbstractValidator<CreateProductCommand>
{
    public Validator()
    {
        RuleFor(x => x.Id).NotEmpty().NotNull();
        RuleFor(x => x.Name).NotEmpty().NotNull().MaximumLength(100);
        RuleFor(x => x.Price).GreaterThan(0);
        RuleFor(x => x.Quantity).GreaterThan((ushort)0);
        RuleFor(x => x.Tenant).NotEmpty().NotNull();
        RuleFor(x => x.CreatedBy).NotEmpty().NotNull();
    }
}


