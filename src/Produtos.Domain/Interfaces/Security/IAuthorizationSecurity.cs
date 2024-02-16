using Produtos.Domain.Models;

namespace Produtos.Domain.Interfaces.Security;

public interface IAuthorizationSecurity
{
    string CreateToken(Usuario usuario);
}