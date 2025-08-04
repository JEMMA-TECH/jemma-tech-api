using JemmaAPI.Entities.Base;
using JemmaAPI.Entities.Customers;

namespace JemmaAPI.Entities.Orders;

public class OrderDto : BaseDto
{
    public Guid CustomerId { get; set; }
    
    public CustomerDto Customer { get; set; }
}