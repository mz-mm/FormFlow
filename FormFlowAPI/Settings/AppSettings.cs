namespace FormFlowAPI.Settings;

public class AppSettings(IConfiguration configuration)
{
    public readonly string UserDbConnectionString = configuration["ConnectionStrings:UserDb"]!;
    public readonly string FormDbConnectionString = configuration["ConnectionStrings:FormDb"]!;
    
    public readonly string Key = configuration["JwtSettings:Key"]!;
    public readonly int ExpireTime = Convert.ToInt32(configuration["JwtSettings:ExpireTime"]);
    public readonly string Issuer = configuration["JwtSettings:Issuer"]!;
    public readonly string Audience = configuration["JwtSettings:Audience"]!;
}
