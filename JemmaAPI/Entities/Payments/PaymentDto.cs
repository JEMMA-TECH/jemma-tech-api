using JemmaAPI.Entities.Base;
using JemmaAPI.Entities.Customers;
using JemmaAPI.Entities.Orders;

namespace JemmaAPI.Entities.Payments;

public class PaymentDto : BaseDto
{
    public decimal Amount { get; set; }
    
    public Guid CustomerId { get; set; }
    
    public CustomerDto Customer { get; set; }
    
    public Guid OrderId { get; set; }
    
    public OrderDto Order { get; set; }
    
    public PaymentMethod PaymentMethod { get; set; }
    
    public PaymentStatus PaymentStatus { get; set; }
}