using JemmaAPI.Entities.Base;
using Microsoft.AspNetCore.Identity;

namespace JemmaAPI.Entities.Users;

public class User : IdentityUser<Guid>, IBaseEntity
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public bool IsActive { get; set; } = true;
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } =  DateTime.UtcNow;
}