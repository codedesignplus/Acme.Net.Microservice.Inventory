namespace Acme.Net.Microservice.Inventory.Application.Inventory.Commands.UpdateInventory;

[DtoGenerator]
public record UpdateInventoryCommand(Guid Id, string Name) : IRequest;

public class Validator : AbstractValidator<UpdateInventoryCommand>
{
    public Validator()
    {
        RuleFor(x => x.Id).NotEmpty().NotNull();
        RuleFor(x => x.Name).NotEmpty().NotNull().MaximumLength(100);
    }
}
