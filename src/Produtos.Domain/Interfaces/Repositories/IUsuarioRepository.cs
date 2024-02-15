using Produtos.Domain.Models;

namespace Produtos.Domain.Interfaces.Repositories;

public interface IUsuarioRepository : IBaseRepository<Usuario>
{
    Task<Usuario> Get(string login, string senha);
}
