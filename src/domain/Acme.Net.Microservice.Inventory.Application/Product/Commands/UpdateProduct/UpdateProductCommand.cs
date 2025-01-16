namespace Acme.Net.Microservice.Inventory.Application.Product.Commands.UpdateProduct;

public record UpdateProductCommand(Guid Id, string Name, long Price, ushort Quantity, Guid UpdatedBy) : IRequest;

public class Validator : AbstractValidator<UpdateProductCommand>
{
    public Validator()
    {
        RuleFor(x => x.Id).NotEmpty().NotNull();
        RuleFor(x => x.Name).NotEmpty().NotNull().MaximumLength(100);
        RuleFor(x => x.Price).GreaterThan(0);
        RuleFor(x => x.Quantity).GreaterThan((ushort)0);
        RuleFor(x => x.UpdatedBy).NotEmpty().NotNull();
    }
}
