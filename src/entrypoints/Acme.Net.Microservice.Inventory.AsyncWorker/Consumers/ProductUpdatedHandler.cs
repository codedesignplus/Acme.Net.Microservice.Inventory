using Acme.Net.Microservice.Inventory.Application.Product.Commands.UpdateProduct;
using MediatR;
using ProductUpdatedDomainEvent = Acme.Net.Microservice.Inventory.AsyncWorker.DomainEvents.ProductUpdatedDomainEvent;

namespace Acme.Net.Microservice.Inventory.AsyncWorker.Consumers;

[QueueName("Product", "update-product")]
public class ProductUpdatedHandler(ILogger<ProductUpdatedHandler> logger, IMediator mediator) : IEventHandler<ProductUpdatedDomainEvent>
{
    public Task HandleAsync(ProductUpdatedDomainEvent data, CancellationToken token)
    {
        logger.LogInformation("ProductUpdatedDomainEvent Recived, {Json}", JsonSerializer.Serialize(data));

        var command = new UpdateProductCommand(data.AggregateId, data.Name, data.Price, data.Quantity, data.UpdatedBy);

        return mediator.Send(command, token);
    }
}
