using JemmaAPI.Entities.Items;
using JemmaAPI.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JemmaAPI.Controllers;

[ApiController]
[Route("api/v{version:apiVersion}/items")]
[Authorize]
public class ItemController(IItemRepository repository) : ControllerBase
{

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Guid))]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    public async Task<IResult> CreateItem([FromBody] CreateItemRequest request)
    {
        return await repository.CreateItem(request);
    }

    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<ItemDto>))]
    public async Task<IResult> GetItems([FromQuery] int page, [FromQuery] int pageSize, [FromQuery] string search)
    {
        return await repository.GetItems(page, pageSize, search);
    }

    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(ItemDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IResult> GetItem(Guid id)
    {
        return await repository.GetItem(id);
    }

    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent, Type = typeof(ItemDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IResult> UpdateItem([FromRoute] Guid id, [FromBody] CreateItemRequest request)
    {
        return await repository.UpdateItem(id, request);
    }

    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent)]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IResult> DeleteItem([FromRoute] Guid id)
    {
        return await repository.DeleteItem(id);
    }
}