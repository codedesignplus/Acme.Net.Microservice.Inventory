namespace Acme.Net.Microservice.Inventory.Application.Inventory.Commands.CreateInventory;

[DtoGenerator]
public record CreateInventoryCommand(Guid Id, string Name, string Code) : IRequest;

public class Validator : AbstractValidator<CreateInventoryCommand>
{
    public Validator()
    {
        RuleFor(x => x.Id).NotEmpty().NotNull();
        RuleFor(x => x.Name).NotEmpty().NotNull();
        RuleFor(x => x.Code).NotEmpty().NotNull();
    }
}
