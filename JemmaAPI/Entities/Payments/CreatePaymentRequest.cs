using System.ComponentModel.DataAnnotations;

namespace JemmaAPI.Entities.Payments;

public class CreatePaymentRequest
{
    [Required] public decimal Amount { get; set; }
    
    [Required] public Guid CustomerId { get; set; }
    
    [Required] public Guid OrderId { get; set; }
    
    [Required] public PaymentMethod PaymentMethod { get; set; }
    
    public PaymentStatus PaymentStatus { get; set; } =  PaymentStatus.Pending;
}