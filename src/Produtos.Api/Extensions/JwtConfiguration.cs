using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Produtos.Domain.Interfaces.Security;
using Produtos.Infra.Security.Services;
using Produtos.Infra.Security.Settings;
using System.Text;

namespace Produtos.Api.Extensions;

public class JwtConfiguration
{
    /// <summary>
    /// Método para adicionar a configuração do JWT
    /// </summary>
    public static void AddJwtBearerSecurity(WebApplicationBuilder builder)
    {
        builder.Services.Configure<JwtSettings>(builder.Configuration.GetSection("JwtSettings"));
        builder.Services.AddTransient<IAuthorizationSecurity, AuthorizationSecurity>();

        builder.Services.AddAuthentication(
            auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }
            ).AddJwtBearer(
            bearer =>
            {
                bearer.RequireHttpsMetadata = false;
                bearer.SaveToken = true;
                bearer.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(
                        Encoding.ASCII.GetBytes
                        (builder.Configuration.GetSection("JwtSettings").GetSection("SecretKey").Value)
                        ),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                };
            });
    }
}
