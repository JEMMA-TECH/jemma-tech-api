using System.Net;
using JemmaAPI.Constants;
using JemmaAPI.Context;
using JemmaAPI.Entities.Base;
using JemmaAPI.Entities.Companies;
using JemmaAPI.Entities.Users;
using JemmaAPI.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.EntityFrameworkCore;
using RegisterRequest = JemmaAPI.Entities.Auth.RegisterRequest;

namespace JemmaAPI.Repositories;

public class AuthRepository(UserManager<User> userManager, ApplicationDbContext context) : IAuthRepository
{
    public async Task<Result<LoginRequest>> Login(LoginRequest request)
    {
        //TODO: check this implementation well
        var employee = await userManager.FindByEmailAsync(request.Email);

        if (employee == null) return new Result<LoginRequest>(HttpStatusCode.BadRequest,
            Messages.LoginFailed, false);
        
        var password = await userManager.CheckPasswordAsync(employee, request.Password);
        return password ? new Result<LoginRequest>(HttpStatusCode.OK, Messages.LoginSuccessful, data: request)
            : new Result<LoginRequest>(HttpStatusCode.BadRequest, Messages.LoginFailed, false);
    }
    

    public async Task<Result<IdentityUser>> Register(RegisterRequest request)
    {
        var existingUser = await userManager.FindByEmailAsync(request.Email);
        if (existingUser != null) return new Result<IdentityUser>(HttpStatusCode.BadRequest,
            Messages.UserAlreadyExistsMessage, false);
        
        var existingCompany = await context.Companies.FirstOrDefaultAsync(c => c.Email == request.CompanyEmail);
        if (existingCompany != null)
            return new Result<IdentityUser>(HttpStatusCode.BadRequest, Messages.CustomerAlreadyExistsMessage, false);

        var user = new User
        {
            Email = request.Email,
            FirstName = request.FirstName,
            LastName = request.LastName,
            UserName = request.Email,
            PhoneNumber = request.Phone
        };
        
        await userManager.CreateAsync(user, request.Password);
  
        var company = new Company
        {
            Address = request.Address,
            Email = request.CompanyEmail,
            PhoneNumber = request.CompanyPhone,
            Name = request.CompanyName
        };

        await context.Companies.AddAsync(company);
        await context.SaveChangesAsync();

        return new Result<IdentityUser>(HttpStatusCode.Created, Messages.RegisterSuccessful);

    }

    public async Task<Result<IdentityUser>> GetUser(string email)
    {
        throw new NotImplementedException();
    }

    public async Task<Result<bool>> UpdateUser(IdentityUser user)
    {
        throw new NotImplementedException();
    }
}