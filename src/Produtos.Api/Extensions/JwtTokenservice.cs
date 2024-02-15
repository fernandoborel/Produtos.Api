using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Produtos.Api.Extensions;

/// <summary>
/// Classe para gerar o token JWT
/// </summary>
public static class JwtTokenservice
{
    /// <summary>
    /// Chave secreta para assinar o token
    /// </summary>
    public static string SecretKey 
        => "ad2024d9-ba2f-4b52-b098-af39e22989e2";

    /// <summary>
    /// Tempo de expiração do token em horas
    /// </summary>
    public static int ExpirationInHours 
        => 6;

    /// <summary>
    /// Gera um token JWT
    /// </summary>
    public static string GenerateToken(string login)
    {
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(SecretKey);

        var descriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new Claim[]
            {
                new(ClaimTypes.Name, login)
            }),
            Expires = DateTime.UtcNow.AddHours(ExpirationInHours),
            SigningCredentials = new(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };

        var token = tokenHandler.CreateToken(descriptor);
        return tokenHandler.WriteToken(token);
    }
}
