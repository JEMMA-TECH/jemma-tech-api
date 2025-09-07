using JemmaAPI.Entities.Orders;
using JemmaAPI.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JemmaAPI.Controllers;

[ApiController]
[Route("api/v{version:apiVersion}/orders")]
[Authorize]
public class OrderController(IOrderRepository repository) : ControllerBase
{

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Guid))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<IResult> CreateOrder([FromBody] CreateOrderRequest request)
    {
        return await repository.CreateOrder(request);
    }
    
    /// <summary>
    /// Retrieves order details
    /// </summary>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK,  Type = typeof(IEnumerable<OrderDto>))]
    public async Task<IResult> GetOrders([FromQuery] int page = 1, [FromQuery] int pageSize = 10, [FromQuery] string search = null)
    {
        return await repository.GetOrders(page, pageSize, search);
    }
    
    /// <summary>
    /// Retrieves the details of an order by its ID.
    /// </summary>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK,  Type = typeof(OrderDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IResult> GetOrder([FromRoute] Guid id)
    {
        return await repository.GetOrder(id);
    }

    /// <summary>
    /// Updates the details of an order by its ID.
    /// </summary>
    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent,  Type = typeof(OrderDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
    public async Task<IResult> UpdateOrder([FromRoute] Guid id, [FromBody] CreateOrderRequest order)
    {
        return await repository.UpdateOrder(id, order);
    }
    
    /// <summary>
    /// Deletes an order by its ID.
    /// </summary>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent,  Type = typeof(OrderDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IResult> DeleteOrder([FromRoute] Guid id)
    {
        return await repository.DeleteOrder(id);
    }
}