using JemmaAPI.Entities.Base;

namespace JemmaAPI.Entities.Customers;

public class Customer : BaseEntity
{
    public string FirstName { get; set; }
    
    public string LastName { get; set; }
    
    public string Email { get; set; }
    
    public string PhoneNumber { get; set; }
    
}