using System.ComponentModel.DataAnnotations;

namespace JemmaAPI.Entities.Orders;

public class CreateOrderRequest
{
    [Required] public Guid CustomerId { get; set; }
    [Required] public List<Guid> OrderItemIds { get; set; }
}