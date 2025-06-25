using System.ComponentModel.DataAnnotations;

namespace JemmaAPI.Entities.Auth;

public class LoginRequest
{
    [Required, EmailAddress] public string Email { get; set; }
    
    [Required] public string Password { get; set; }
}