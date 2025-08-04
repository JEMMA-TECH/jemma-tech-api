using JemmaAPI.Entities.Base;
using JemmaAPI.Entities.Customers;

namespace JemmaAPI.Interfaces;

public interface ICustomerRepository
{
    Task<Result<Guid>> CreateCustomer(CreateCustomerRequest request);
    Task<Result<IEnumerable<CustomerDto>>> GetCustomers(int page, int pageSize, string search);
    Task<Result<CustomerDto>> GetCustomer(Guid id);
    
    Task<Result<CustomerDto>> UpdateCustomer(Guid id, CreateCustomerRequest request);
    Task<Result<bool>> DeleteCustomer(Guid id);
}