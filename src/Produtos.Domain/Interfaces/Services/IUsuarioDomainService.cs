using Produtos.Domain.Models;

namespace Produtos.Domain.Interfaces.Services;

public interface IUsuarioDomainService : IDisposable
{
    Task<Usuario> Get(string login, string senha);

    Task Adicionar(Usuario usuario);
    Task Atualizar(Usuario usuario);
    Task Remover(Guid id);

    Task<IEnumerable<Usuario>> ObterTodos();
    Task<Usuario> ObterPorId(Guid id);
}
