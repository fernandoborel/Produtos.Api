using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Produtos.Domain.Interfaces.Security;
using Produtos.Domain.Models;
using Produtos.Infra.Security.Settings;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Produtos.Infra.Security.Services;

public class AuthorizationSecurity : IAuthorizationSecurity
{
    private readonly JwtSettings _jwtSettings;

    public AuthorizationSecurity(IOptions<JwtSettings> jwtSettings)
    {
        _jwtSettings = jwtSettings.Value;
    }

    public string CreateToken(Usuario usuario)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_jwtSettings.SecretKey);

        var tokenDescriptor = new SecurityTokenDescriptor
        {
            //Gravar os dados do usuário no token
            Subject = new ClaimsIdentity(new Claim[]
            {
                    new Claim(ClaimTypes.Name, usuario.Login), // Email do usuário autenticado
                    new Claim(ClaimTypes.Role, "USER") // Perfil do usuário autenticado
            }),
            //definindo a data e hora de expiração
            Expires = DateTime.UtcNow.AddHours(_jwtSettings.ExpirationInHours),

            //criptografar a chave antifalsificação no token
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key),
            SecurityAlgorithms.HmacSha256Signature)
        };

        //retornando o token
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}