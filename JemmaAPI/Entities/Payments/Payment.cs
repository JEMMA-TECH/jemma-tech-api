using JemmaAPI.Entities.Base;
using JemmaAPI.Entities.Customers;
using JemmaAPI.Entities.Orders;

namespace JemmaAPI.Entities.Payments;

public class Payment : BaseEntity
{
    public decimal Amount { get; set; }
    
    public Guid CustomerId { get; set; }
    
    public Customer Customer { get; set; }
    
    public Guid OrderId { get; set; }
    
    public Order Order { get; set; }
    
    public PaymentMethod PaymentMethod { get; set; }
    
    public PaymentStatus PaymentStatus { get; set; } =  PaymentStatus.Pending;
    
}

public enum PaymentMethod
{
    Cash,
    DebitCard,
    MobileMoney
}

public enum PaymentStatus
{
    Pending,
    Partial,
    Paid,
    Refunded,
    Rejected
}