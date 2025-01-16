namespace Acme.Net.Microservice.Inventory.Application.Inventory.Commands.RemoveProduct;

[DtoGenerator]
public record RemoveProductCommand(Guid Id, Guid IdProduct) : IRequest;

public class Validator : AbstractValidator<RemoveProductCommand>
{
    public Validator()
    {
        RuleFor(x => x.Id).NotEmpty().NotNull();
    }
}
