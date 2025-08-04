using System.ComponentModel.DataAnnotations;

namespace JemmaAPI.Entities.Services;

public class CreateServiceRequest
{
    [Required] public string Name { get; set; }
}