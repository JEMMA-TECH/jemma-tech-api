using System.ComponentModel.DataAnnotations;

namespace JemmaAPI.Entities.Items;

public class CreateItemRequest
{
    [Required] public string Name { get; set; }
    
    [Range(1, int.MaxValue)] public decimal Price { get; set; }
    
    [Required] public Guid ServiceId { get; set; }
}