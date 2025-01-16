namespace Acme.Net.Microservice.Inventory.Application.Inventory.Commands.AddProduct;

[DtoGenerator]
public record AddProductCommand(Guid Id, Guid IdProduct, string Name, ushort Quantity, long Price) : IRequest;

public class Validator : AbstractValidator<AddProductCommand>
{
    public Validator()
    {
        RuleFor(x => x.Id).NotEmpty().NotNull();
    }
}
