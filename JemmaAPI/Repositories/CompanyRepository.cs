using System.Net;
using AutoMapper;
using JemmaAPI.Constants;
using JemmaAPI.Context;
using JemmaAPI.Entities.Base;
using JemmaAPI.Entities.Companies;
using JemmaAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JemmaAPI.Repositories;

public class CompanyRepository(ApplicationDbContext context, IMapper mapper) : ICompanyRepository
{
    public async Task<Result<IEnumerable<CompanyDto>>> GetAllCompanies(int page, int pageSize, string search)
    {
        var query = context.Companies.AsQueryable();
        return new Result<IEnumerable<CompanyDto>>(HttpStatusCode.OK, Messages.CompaniesRetrieved,
            data:mapper.Map<IEnumerable<CompanyDto>>(await query.ToListAsync()));
    }

    public async Task<Result<CompanyDto>> GetCompany(Guid id)
    {
        var  company = await context.Companies.FirstOrDefaultAsync(c => c.Id == id);
        return company == null ? 
            new Result<CompanyDto>(HttpStatusCode.NotFound, Messages.CompanyNotFound) 
            : new Result<CompanyDto>(HttpStatusCode.OK, Messages.CompanyFound, data:mapper.Map<CompanyDto>(company));
    }

    public async Task<Result<CompanyDto>> UpdateCompany(Guid id, CompanyDto company)
    {
        var existingCompany = await context.Companies.FirstOrDefaultAsync(c => c.Id == id);
        if (existingCompany == null)
        {
            return new Result<CompanyDto>(HttpStatusCode.NotFound, Messages.CompanyNotFound);
        }
        
        var updatedCompany = mapper.Map(company, existingCompany);
        context.Companies.Update(updatedCompany);
        await context.SaveChangesAsync();
        
        return new Result<CompanyDto>(HttpStatusCode.OK, Messages.CompanyUpdated,
            data:mapper.Map<CompanyDto>(updatedCompany));
    }

    public async Task<Result<bool>> DeleteCompany(Guid id)
    {
        var company = await context.Companies.FirstOrDefaultAsync(c => c.Id == id);
        if (company == null)
        {
            return new Result<bool>(HttpStatusCode.NotFound, Messages.CompanyNotFound);
        }
        context.Companies.Remove(company);
        await context.SaveChangesAsync();
        
        return new Result<bool>(HttpStatusCode.NoContent,  Messages.CompanyDeleted);
    }
}