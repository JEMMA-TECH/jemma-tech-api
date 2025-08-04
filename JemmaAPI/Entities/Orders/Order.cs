using JemmaAPI.Entities.Base;
using JemmaAPI.Entities.Customers;
using JemmaAPI.Entities.OrderItems;

namespace JemmaAPI.Entities.Orders;

public class Order : BaseEntity
{
    public Guid CustomerId { get; set; }
    
    public Customer Customer { get; set; }
    
    public List<OrderItem> OrderItems { get; set; }
}