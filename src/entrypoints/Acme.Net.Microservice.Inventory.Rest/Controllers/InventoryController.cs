using CodeDesignPlus.Microservice.Api.Dtos;

namespace Acme.Net.Microservice.Inventory.Rest.Controllers;

/// <summary>
/// Controller class responsible for handling HTTP requests related to Inventorys.
/// </summary>
/// <param name="mediator">Mediator instance for sending commands and queries.</param>
/// <param name="mapper">Mapper instance for mapping between DTOs and commands/queries.</param>
[Route("api/[controller]")]
[ApiController]
public class InventoryController(IMediator mediator, IMapper mapper) : ControllerBase
{
    /// <summary>
    /// Get all Inventorys.
    /// </summary>
    /// <param name="criteria">Criteria for filtering and sorting the Inventorys.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>Collection of Inventorys.</returns>
    [HttpGet]
    public async Task<IActionResult> GetInventorys([FromQuery] C.Criteria criteria, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetAllInventoriesQuery(criteria), cancellationToken);

        return Ok(result);
    }

    /// <summary>
    /// Get a Inventory by its ID.
    /// </summary>
    /// <param name="id">The unique identifier of the Inventory.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The Inventory.</returns>
    [HttpGet("{id}")]
    public async Task<IActionResult> GetInventoryById(Guid id, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetInventoryByIdQuery(id), cancellationToken);

        return Ok(result);
    }
    
    /// <summary>
    /// Get all Products by Inventory.
    /// </summary>
    /// <param name="id">The unique identifier of the Inventory.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The Inventory.</returns>
    [HttpGet("{id}/Products")]
    public async Task<IActionResult> GetProductsById(Guid id, CancellationToken cancellationToken)
    {
        var result = await mediator.Send(new GetProductsByInventoryQuery(id), cancellationToken);

        return Ok(result);
    }

    /// <summary>
    /// Create a new Inventory.
    /// </summary>
    /// <param name="data">Data for creating the Inventory.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>HTTP status code 204 (No Content).</returns>
    [HttpPost("Products")]
    public async Task<IActionResult> CreateInventory([FromBody] CreateInventoryDto data, CancellationToken cancellationToken)
    { 
        await mediator.Send(mapper.Map<CreateInventoryCommand>(data), cancellationToken);

        return NoContent();
    }

    /// <summary>
    /// Update an existing Inventory.
    /// </summary>
    /// <param name="id">The unique identifier of the Inventory.</param>
    /// <param name="data">Data for updating the Inventory.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>HTTP status code 204 (No Content).</returns>
    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateInventory(Guid id, [FromBody] UpdateInventoryDto data, CancellationToken cancellationToken)
    {
        data.Id = id;

        await mediator.Send(mapper.Map<UpdateInventoryCommand>(data), cancellationToken);

        return NoContent();
    }

    /// <summary>
    /// Delete a Inventory by its ID.
    /// </summary>
    /// <param name="id">The unique identifier of the Inventory.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>HTTP status code 204 (No Content).</returns>
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteInventory(Guid id, CancellationToken cancellationToken)
    {
        await mediator.Send(new DeleteInvetoryCommand(id), cancellationToken);

        return NoContent();
    }

    
    /// <summary>
    /// Add products to an existing Inventory. 
    /// </summary>
    /// <param name="data">Data for adding the products.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>HTTP status code 204 (No Content).</returns>
    [HttpPost("Product")]
    public async Task<IActionResult> AddProduct([FromBody] AddProductDto data, CancellationToken cancellationToken)
    { 
        await mediator.Send(mapper.Map<AddProductCommand>(data), cancellationToken);

        return NoContent();
    }

    /// <summary>
    /// Update an existing product in an Inventory.
    /// </summary>
    /// <param name="id">The unique identifier of the Inventory.</param>
    /// <param name="data">Data for updating the product.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>HTTP status code 204 (No Content).</returns>
    [HttpPut("{id}/Product")]
    public async Task<IActionResult> UpdateProduct(Guid id, [FromBody] UpdateProductDto data, CancellationToken cancellationToken)
    {
        data.Id = id;

        await mediator.Send(mapper.Map<UpdateInventoryCommand>(data), cancellationToken);

        return NoContent();
    }

    /// <summary>
    /// Remove a product from an Inventory by its ID.
    /// </summary>
    /// <param name="id">The unique identifier of the Inventory.</param>
    /// <param name="idProduct">The unique identifier of the Product.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>HTTP status code 204 (No Content).</returns>
    [HttpDelete("{id}/Product/{idProduct}")]
    public async Task<IActionResult> RemoveProduct(Guid id, Guid idProduct, CancellationToken cancellationToken)
    {
        await mediator.Send(new DeleteInvetoryCommand(id), cancellationToken);

        return NoContent();
    }
}
