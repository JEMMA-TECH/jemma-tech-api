using JemmaAPI.Entities.Base;
using JemmaAPI.Entities.Users;

namespace JemmaAPI.Interfaces;

public interface IEmployeeRepository
{
    Task<Result<Guid>> GetEmployees(int page, int pageSize, string searchQuery);
    
    Task<Result<UserDto>> UpdateEmployee(Guid id, UserDto user);
    Task<Result<UserDto>> GetEmployee(Guid id);
    Task<Result<Guid>> DeleteEmployee(Guid id);
}