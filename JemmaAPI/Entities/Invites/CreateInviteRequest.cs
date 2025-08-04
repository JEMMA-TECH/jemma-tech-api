using System.ComponentModel.DataAnnotations;

namespace JemmaAPI.Entities.Invites;

public class CreateInviteRequest
{
    [Required, EmailAddress] public string Email { get; set; }
}