using JemmaAPI.Entities.Base;

namespace JemmaAPI.Entities.Customers;

public class CustomerDto : BaseDto
{
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public string Email { get; set; }
    
    public string PhoneNumber { get; set; }
}