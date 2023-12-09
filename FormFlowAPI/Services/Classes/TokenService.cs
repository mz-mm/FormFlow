using System.Globalization;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using FormFlowApi.Data.Models;
using FormFlowAPI.Services.Interfaces;
using FormFlowAPI.Settings;
using Microsoft.IdentityModel.Tokens;
using JwtRegisteredClaimNames = System.IdentityModel.Tokens.Jwt.JwtRegisteredClaimNames;

namespace FormFlowAPI.Services.Classes;

public class TokenService(AppSettings appSettings) : ITokenService
{
    public string CreateToken(ApplicationUser applicationUser)
    {
        var token = CreateJwtToken(
            claims: CreateClaims(applicationUser),
            credentials: CreateSigningCredentials(),
            expiration: DateTime.UtcNow.AddMinutes(appSettings.ExpireTime)
        );

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

    private JwtSecurityToken CreateJwtToken(IEnumerable<Claim> claims, SigningCredentials credentials, DateTime expiration) =>
        new(
            claims: claims,
            expires: expiration,
            signingCredentials: credentials
        );

    private List<Claim> CreateClaims(ApplicationUser applicationUser)
    {
        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Iat, DateTime.UtcNow.ToString(CultureInfo.InvariantCulture)),
            new Claim(JwtRegisteredClaimNames.Sub, applicationUser.Id),
            new Claim(ClaimTypes.Name, applicationUser.UserName!),
            new Claim(ClaimTypes.Email, applicationUser.Email!),
        };

        return claims;
    }

    private SigningCredentials CreateSigningCredentials()
    {
        return new SigningCredentials(
            new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(appSettings.Key)
            ),
            SecurityAlgorithms.HmacSha256
        );
    }
}
