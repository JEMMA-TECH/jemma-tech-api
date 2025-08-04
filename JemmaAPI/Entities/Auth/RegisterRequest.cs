using System.ComponentModel.DataAnnotations;

namespace JemmaAPI.Entities.Auth;

public class RegisterRequest
{
    [Required] public string CompanyName { get; set; }
    
    [Required] public string Address { get; set; }
    
    [Required, EmailAddress] public string CompanyEmail { get; set; }
    
    [Required, Phone] public string CompanyPhone { get; set; }
    
    [Required] public string FirstName { get; set; }
    
    [Required] public string LastName { get; set; }
    
    [Required, EmailAddress] public string Email { get; set; }
    
    [Required, Phone] public string Phone { get; set; }
    
    [Required, MinLength(6)] public string Password { get; set; }
}