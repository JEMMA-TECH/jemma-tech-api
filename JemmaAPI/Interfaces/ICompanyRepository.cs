using JemmaAPI.Entities.Base;
using JemmaAPI.Entities.Companies;

namespace JemmaAPI.Interfaces;

public interface ICompanyRepository
{
    Task<Result<IEnumerable<CompanyDto>>> GetAllCompanies(int page, int pageSize,  string search);
    Task<Result<CompanyDto>> GetCompany(Guid id);
    Task<Result<CompanyDto>> UpdateCompany(Guid id, CompanyDto company);
    Task<Result<bool>> DeleteCompany(Guid id);
}