namespace Acme.Net.Microservice.Inventory.Application.Inventory.Commands.UpdateProduct;

[DtoGenerator]
public record UpdateProductCommand(Guid Id, Guid IdProduct, string Name, ushort Quantity, long Price) : IRequest;

public class Validator : AbstractValidator<UpdateProductCommand>
{
    public Validator()
    {
        RuleFor(x => x.Id).NotEmpty().NotNull();
    }
}
