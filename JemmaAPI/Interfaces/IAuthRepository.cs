using JemmaAPI.Entities.Base;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using RegisterRequest = JemmaAPI.Entities.Auth.RegisterRequest;

namespace JemmaAPI.Interfaces;

public interface IAuthRepository
{
    Task<Result<LoginRequest>> Login(LoginRequest request);
    Task<Result<IdentityUser>> Register(RegisterRequest request);
    Task<Result<IdentityUser>> GetUser(string email);
    
    Task<Result<bool>> UpdateUser(IdentityUser user);
    
    
}