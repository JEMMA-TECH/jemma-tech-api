using JemmaAPI.Entities.Base;
using JemmaAPI.Entities.Services;

namespace JemmaAPI.Entities.Items;

public class ItemDto : BaseDto
{
    public string Name { get; set; }
    
    public decimal Price { get; set; }
    
    public Guid ServiceId { get; set; }
    
    public ServiceDto Service { get; set; }
}