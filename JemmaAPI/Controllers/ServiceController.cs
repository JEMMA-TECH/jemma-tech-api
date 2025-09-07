using JemmaAPI.Entities.Services;
using JemmaAPI.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JemmaAPI.Controllers;

[ApiController]
[Route("api/v{version:apiVersion}/services")]
[Authorize]
public class ServiceController(IServiceRepository repository) : ControllerBase
{
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Guid))]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IResult> CreateService([FromBody] CreateServiceRequest request)
    {
        return await repository.CreateService(request);
    }
    /// <summary>
    /// Retrieves service details
    /// </summary>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK,  Type = typeof(IEnumerable<ServiceDto>))]
    public async Task<IResult> GetServices([FromQuery] int page = 1, [FromQuery] int pageSize = 10, [FromQuery] string search = null)
    {
        return await repository.GetAllServices(page, pageSize, search);
    }
    
    /// <summary>
    /// Retrieves the details of a service by its ID.
    /// </summary>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK,  Type = typeof(ServiceDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IResult> GetService([FromRoute] Guid id)
    {
        return await repository.GetService(id);
    }

    /// <summary>
    /// Updates the details of a service by its ID.
    /// </summary>
    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent,  Type = typeof(ServiceDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
    public async Task<IResult> UpdateService([FromRoute] Guid id, [FromBody] CreateServiceRequest service)
    {
        return await repository.UpdateService(id, service);
    }
    
    /// <summary>
    /// Deletes a service by its ID.
    /// </summary>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent,  Type = typeof(ServiceDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IResult> DeleteService([FromRoute] Guid id)
    {
        return await repository.DeleteService(id);
    }
}