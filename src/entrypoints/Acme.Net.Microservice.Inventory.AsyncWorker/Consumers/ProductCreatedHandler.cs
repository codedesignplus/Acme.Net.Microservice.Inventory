using Acme.Net.Microservice.Inventory.Application.Product.Commands.CreateProduct;
using MediatR;
using ProductCreatedDomainEvent = Acme.Net.Microservice.Inventory.AsyncWorker.DomainEvents.ProductCreatedDomainEvent;

namespace Acme.Net.Microservice.Inventory.AsyncWorker.Consumers;

[QueueName("Product", "create-product")]
public class ProductCreatedHandler(ILogger<ProductCreatedHandler> logger, IMediator mediator) : IEventHandler<ProductCreatedDomainEvent>
{
    public Task HandleAsync(ProductCreatedDomainEvent data, CancellationToken token)
    {
        logger.LogInformation("ProductCreatedHandler Recived, {Json}", JsonSerializer.Serialize(data));

        var command = new CreateProductCommand(data.AggregateId, data.Name, data.Price, data.Quantity, data.Tenant, data.CreatedBy);

        return mediator.Send(command, token);
    }
}
