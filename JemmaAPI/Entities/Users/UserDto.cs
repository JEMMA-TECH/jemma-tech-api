using JemmaAPI.Entities.Base;

namespace JemmaAPI.Entities.Users;

public class UserDto : BaseDto
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
}