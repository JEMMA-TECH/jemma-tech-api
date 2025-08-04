using JemmaAPI.Entities.Users;
using JemmaAPI.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JemmaAPI.Controllers;

public class EmployeeController(IEmployeeRepository repository) : ControllerBase
{
    
    /// <summary>
    /// Retrieves employee details
    /// </summary>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK,  Type = typeof(IEnumerable<UserDto>))]
    public async Task<IResult> GetEmployees([FromQuery] int page = 1, [FromQuery] int pageSize = 10, [FromQuery] string search = null)
    {
        return await repository.GetEmployees(page, pageSize, search);
    }
    
    /// <summary>
    /// Retrieves the details of an employee by its ID.
    /// </summary>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK,  Type = typeof(UserDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IResult> GetEmployee([FromRoute] Guid id)
    {
        return await repository.GetEmployee(id);
    }

    /// <summary>
    /// Updates the details of an employee by its ID.
    /// </summary>
    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent,  Type = typeof(UserDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
    public async Task<IResult> UpdateEmployee([FromRoute] Guid id, [FromBody] UserDto employee)
    {
        return await repository.UpdateEmployee(id, employee);
    }
    
    /// <summary>
    /// Deletes an employee by its ID.
    /// </summary>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent,  Type = typeof(UserDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IResult> DeleteEmployee([FromRoute] Guid id)
    {
        return await repository.DeleteEmployee(id);
    }
}