using JemmaAPI.Entities.Base;

namespace JemmaAPI.Entities.Companies;

public class Company : BaseEntity
{
    public string Name { get; set; }
    
    public string Address { get; set; }
    
    public string PhoneNumber { get; set; }
    
    public string Email { get; set; }
    
}