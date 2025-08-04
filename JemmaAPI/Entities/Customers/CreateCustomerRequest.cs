using System.ComponentModel.DataAnnotations;

namespace JemmaAPI.Entities.Customers;

public class CreateCustomerRequest
{
    [Required] public string FirstName { get; set; }
    
    [Required] public string LastName { get; set; }
    
    [Required, EmailAddress] public string Email { get; set; }
    
    [Required, Phone] public string PhoneNumber { get; set; }
}