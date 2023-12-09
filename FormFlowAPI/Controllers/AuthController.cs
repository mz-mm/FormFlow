using FormFlowApi.Data.DbContexts;
using FormFlowApi.Data.Models;
using FormFlowAPI.Data.Schemas.Jwt;
using FormFlowAPI.Data.Schemas.User;
using FormFlowAPI.Services.Interfaces;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FormFlowAPI.Controllers;

[ApiController]
[Route("api/auth")]
public class AuthController(UserManager<ApplicationUser> userManager, ITokenService tokenService, ApplicationUsersContext applicationUsersContext)
    : ControllerBase
{
    [HttpPost]
    [Route("register")]
    public async Task<IActionResult> Register([FromBody] RegistrationSchema request)
    {
        var result = await userManager.CreateAsync(new ApplicationUser()
        {
            Email = request.Email,
            UserName = request.Username
        }, request.Password);

        if (!result.Succeeded) return BadRequest(result.Errors);

        return Ok();
    }

    [HttpPost]
    [Route("login")]
    public async Task<ActionResult<AuthResponseSchema>> Authenticate([FromBody] AuthSchema request)
    {
        if (!ModelState.IsValid) return BadRequest(ModelState);

        var managedUser = await userManager.FindByEmailAsync(request.Email);
        if (managedUser is null) return BadRequest("Bad credentials");

        var isPasswordValid = await userManager.CheckPasswordAsync(managedUser, request.Password);
        if (!isPasswordValid) return BadRequest("Bad credentials");

        var userInDb = applicationUsersContext.Users.FirstOrDefault(u => u.Email == request.Email);
        if (userInDb is null) return Unauthorized();

        var accessToken = tokenService.CreateToken(userInDb);

        await applicationUsersContext.SaveChangesAsync();

        return Ok(new AuthResponseSchema
        {
            Username = userInDb.UserName!,
            Email = userInDb.Email!,
            Token = accessToken,
        });
    }
}
