using JemmaAPI.Entities.Companies;
using JemmaAPI.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JemmaAPI.Controllers;

[ApiController]
[Route("api/v{version:apiVersion}/companies")]
[Authorize]
public class CompanyController(ICompanyRepository repository) : ControllerBase
{

    /// <summary>
    /// Retrieves company details
    /// </summary>
    [HttpGet]
    [ProducesResponseType(StatusCodes.Status200OK,  Type = typeof(IEnumerable<CompanyDto>))]
    public async Task<IResult> GetCompanies([FromQuery] int page = 1, [FromQuery] int pageSize = 10, [FromQuery] string search = null)
    {
        return await repository.GetAllCompanies(page, pageSize, search);
    }
    
    /// <summary>
    /// Retrieves the details of a company by its ID.
    /// </summary>
    [HttpGet("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status200OK,  Type = typeof(CompanyDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IResult> GetCompany([FromRoute] Guid id)
    {
        return await repository.GetCompany(id);
    }

    /// <summary>
    /// Updates the details of a company by its ID.
    /// </summary>
    [HttpPut("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent,  Type = typeof(CompanyDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    [ProducesResponseType(StatusCodes.Status406NotAcceptable)]
    public async Task<IResult> UpdateCompany([FromRoute] Guid id, [FromBody] CompanyDto company)
    {
        return await repository.UpdateCompany(id, company);
    }
    
    /// <summary>
    /// Deletes a company by its ID.
    /// </summary>
    [HttpDelete("{id:guid}")]
    [ProducesResponseType(StatusCodes.Status204NoContent,  Type = typeof(CompanyDto))]
    [ProducesResponseType(StatusCodes.Status404NotFound)]
    public async Task<IResult> DeleteCompany([FromRoute] Guid id)
    {
        return await repository.DeleteCompany(id);
    }
}