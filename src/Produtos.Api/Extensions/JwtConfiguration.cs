using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Produtos.Api.Extensions;

public class JwtConfiguration
{
    /// <summary>
    /// Método para adicionar a configuração do JWT
    /// </summary>
    public static void AddJwt(WebApplicationBuilder builder)
    {
        builder.Services.AddAuthentication(auth =>
        {
            auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        })
        .AddJwtBearer(jwt =>
        {
            jwt.RequireHttpsMetadata = false;
            jwt.SaveToken = true;
            jwt.TokenValidationParameters = new()
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(JwtTokenservice.SecretKey)),
                ValidateIssuer = false,
                ValidateAudience = false
            };
        });
    }
}
