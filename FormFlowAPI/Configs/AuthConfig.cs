using System.Text;
using FormFlowApi.Data.DbContexts;
using FormFlowAPI.Services.Classes;
using FormFlowAPI.Services.Interfaces;
using FormFlowAPI.Settings;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;

namespace FormFlowAPI.Configs;

public class AuthConfig
{
    private readonly AppSettings _appSettings;
    private readonly IServiceCollection _services;

    public AuthConfig(AppSettings appSettings, IServiceCollection serviceCollection)
    {
        _appSettings = appSettings;
        _services = serviceCollection;

        Configure();
    }

    private void Configure()
    {
        _services
            .AddIdentity<IdentityUser, IdentityRole>(options =>
            {
                options.SignIn.RequireConfirmedAccount = false;
                options.User.RequireUniqueEmail = true;
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 8;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequireLowercase = false;
            })
            .AddEntityFrameworkStores<ApplicationUsersContext>();

        _services
            .AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters()
                    {
                        ClockSkew = TimeSpan.FromMinutes(_appSettings.ExpireTime),

                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,

                        ValidIssuer = _appSettings.Issuer,
                        ValidAudience = _appSettings.Audience,

                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(_appSettings.Key)
                        ),
                    };
                }
            );

        _services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        });
        
        _services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        _services.AddScoped<ITokenService, TokenService>();
        _services.AddAuthorization();

    }
}
