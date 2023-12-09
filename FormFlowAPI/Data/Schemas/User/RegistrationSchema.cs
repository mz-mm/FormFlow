using System.ComponentModel.DataAnnotations;

namespace FormFlowAPI.Data.Schemas.User;

public class RegistrationSchema
{
    [Required]
    public string Email { get; set; } = null!;
    
    [Required]
    public string Username { get; set; } = null!;
    
    [Required]
    public string Password { get; set; } = null!;
}