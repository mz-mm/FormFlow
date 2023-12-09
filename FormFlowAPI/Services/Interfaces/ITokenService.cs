using FormFlowApi.Data.Models;

namespace FormFlowAPI.Services.Interfaces;

public interface ITokenService
{
    public string CreateToken(ApplicationUser applicationUser);
}
