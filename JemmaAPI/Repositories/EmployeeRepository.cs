using System.Net;
using AutoMapper;
using JemmaAPI.Constants;
using JemmaAPI.Context;
using JemmaAPI.Entities.Base;
using JemmaAPI.Entities.Users;
using JemmaAPI.Interfaces;
using Microsoft.AspNetCore.Identity;

namespace JemmaAPI.Repositories;

public class EmployeeRepository(ApplicationDbContext context, IMapper mapper, UserManager<User> userManager) : IEmployeeRepository
{
    public async Task<Result<Guid>> GetEmployees(int page, int pageSize, string searchQuery)
    {
        var employees = await userManager.GetUsersInRoleAsync("Employee");
        // return await 
        return Results.Ok(Guid.NewGuid()) as Result<Guid>;
    }

    public async Task<Result<UserDto>> UpdateEmployee(Guid id, UserDto user)
    {
        var employee = await userManager.FindByIdAsync(id.ToString());
        if (employee is null) return new Result<UserDto>(HttpStatusCode.NotFound, Messages.UserNotFound);
        mapper.Map(user, employee);
    
        await userManager.UpdateAsync(employee);
        await context.SaveChangesAsync();

        return new Result<UserDto>(HttpStatusCode.NoContent, Messages.UserUpdated);
    }

    public async Task<Result<UserDto>> GetEmployee(Guid id)
    {
        var employee = await userManager.FindByIdAsync(id.ToString());
        return employee is null ? new Result<UserDto>(HttpStatusCode.NotFound, Messages.UserNotFound,false)
            : new Result<UserDto>(HttpStatusCode.OK, Messages.UserRetrieved, data: mapper.Map<UserDto>(employee));
    }

    public async Task<Result<Guid>> DeleteEmployee(Guid id)
    {
        var employee = await userManager.FindByIdAsync(id.ToString());
        if (employee is null) return new Result<Guid>(HttpStatusCode.NotFound, Messages.UserNotFound);
        
        employee.IsActive = false;
        await userManager.UpdateAsync(employee);
        return new Result<Guid>(HttpStatusCode.OK, Messages.UserDeleted);
    }
}