using System.Net;
using AutoMapper;
using JemmaAPI.Constants;
using JemmaAPI.Context;
using JemmaAPI.Entities.Base;
using JemmaAPI.Entities.Customers;
using JemmaAPI.Entities.Items;
using JemmaAPI.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace JemmaAPI.Repositories;

public class CustomerRepository(ApplicationDbContext context, IMapper mapper) : ICustomerRepository
{
    public async Task<Result<Guid>> CreateCustomer(CreateCustomerRequest request)
    {
        var existingCustomer = await context.Customers
            .FirstOrDefaultAsync(c => c.PhoneNumber == request.PhoneNumber || c.Email == request.Email);

        if (existingCustomer != null)
            return new Result<Guid>(HttpStatusCode.Conflict, Messages.CustomerAlreadyExistsMessage, false);
        
        var customer = mapper.Map<Customer>(request);
        await context.Customers.AddAsync(customer);
        await context.SaveChangesAsync();
        
        return new Result<Guid>(HttpStatusCode.OK,Messages.CustomerAdded, data: customer.Id);
    }

    public async Task<Result<IEnumerable<CustomerDto>>> GetCustomers(int page, int pageSize, string search)
    {
        var query = context.Items.AsQueryable();

        if (!string.IsNullOrEmpty(search))
        {
            query = query.Where(s => s.Name.Contains(search));
        }
        
        return new Result<IEnumerable<CustomerDto>>(HttpStatusCode.OK, Messages.CustomersRetrieved,
            data: mapper.Map<IEnumerable<CustomerDto>>(await query.ToListAsync()));
    }

    public async Task<Result<CustomerDto>> GetCustomer(Guid id)
    {
        var customer = await context.Customers.FirstOrDefaultAsync(c => c.Id == id);
        return customer == null ? new Result<CustomerDto>(HttpStatusCode.NotFound, Messages.CustomerNotFound, false) : 
            new Result<CustomerDto>(HttpStatusCode.OK, Messages.CustomerRetrieved,data: mapper.Map<CustomerDto>(customer));
    }

    public async Task<Result<CustomerDto>> UpdateCustomer(Guid id, CreateCustomerRequest request)
    {
        var customer = await context.Customers.FirstOrDefaultAsync(c => c.Id == id);
        if (customer == null) return new Result<CustomerDto>(HttpStatusCode.NotFound, Messages.CustomerNotFound, false) ;
        
        mapper.Map(request, customer);
        context.Customers.Update(customer);
        await context.SaveChangesAsync();
        return new Result<CustomerDto>(HttpStatusCode.NoContent, Messages.CustomerUpdated);
    }

    public async Task<Result<bool>> DeleteCustomer(Guid id)
    {
        var customer = await context.Customers.FirstOrDefaultAsync(c => c.Id == id);
        if (customer == null) return new Result<bool>(HttpStatusCode.NotFound, Messages.CustomerNotFound, false);
        context.Customers.Remove(customer);
        await context.SaveChangesAsync();
        return new Result<bool>(HttpStatusCode.OK, Messages.CustomerDeleted);
        
    }
}