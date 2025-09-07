using JemmaAPI.Entities.Customers;
using JemmaAPI.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JemmaAPI.Controllers;

[ApiController]
[Route("api/v{version:apiVersion}/customers")]
[Authorize]
public class CustomerController(ICustomerRepository repository) : ControllerBase
{
    /// <summary>
    /// Creates a customer
    /// </summary>
    [HttpPost]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(Guid))]
    [ProducesResponseType(StatusCodes.Status409Conflict)]
    [ProducesResponseType(StatusCodes.Status400BadRequest)]
    public async Task<IResult> CreateCustomer([FromBody] CreateCustomerRequest request)
    {
        return await repository.CreateCustomer(request);
    }
    
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(IEnumerable<CustomerDto>))]
    public async Task<IResult> GetCustomers([FromQuery] int page = 1, [FromQuery] int pageSize = 10, [FromQuery] string search = null)
    {
        return await repository.GetCustomers(page, pageSize, search);
    }
    
    /// <summary>
    /// Retrieves the details of a customer by its ID.
    /// </summary>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK,  Type = typeof(CustomerDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IResult> GetCustomer([FromRoute] Guid id)
    {
        return await repository.GetCustomer(id);
    }

    /// <summary>
    /// Updates the details of a customer by its ID.
    /// </summary>
    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent,  Type = typeof(CustomerDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
    public async Task<IResult> UpdateCustomer([FromRoute] Guid id, [FromBody] CreateCustomerRequest customer)
    {
        return await repository.UpdateCustomer(id, customer);
    }
    
    /// <summary>
    /// Deletes a customer by its ID.
    /// </summary>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent,  Type = typeof(CustomerDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IResult> DeleteCustomer([FromRoute] Guid id)
    {
        return await repository.DeleteCustomer(id);
    }
}