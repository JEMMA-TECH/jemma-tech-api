using JemmaAPI.Entities.Base;
using JemmaAPI.Entities.Items;
using JemmaAPI.Entities.Orders;

namespace JemmaAPI.Entities.OrderItems;

public class OrderItem : BaseEntity
{
    public Guid ItemId { get; set; }
    
    public Item Item { get; set; }
    
    public Guid OrderId { get; set; }
    
    public Order Order { get; set; }
    
    public int Quantity { get; set; }
}