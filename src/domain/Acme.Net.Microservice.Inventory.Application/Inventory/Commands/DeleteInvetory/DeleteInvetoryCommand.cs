namespace Acme.Net.Microservice.Inventory.Application.Inventory.Commands.DeleteInvetory;

[DtoGenerator]
public record DeleteInvetoryCommand(Guid Id) : IRequest;

public class Validator : AbstractValidator<DeleteInvetoryCommand>
{
    public Validator()
    {
        RuleFor(x => x.Id).NotEmpty().NotNull();
    }
}
