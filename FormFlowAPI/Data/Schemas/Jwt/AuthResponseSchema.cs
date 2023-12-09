namespace FormFlowAPI.Data.Schemas.Jwt;

public class AuthResponseSchema
{
    public string Username { get; set; } = null!;
    
    public string Email { get; set; } = null!;
    
    public string Token { get; set; } = null!; 
}