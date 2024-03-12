using Produtos.Domain.Models;

namespace Produtos.Domain.Interfaces.Services;

public interface IUsuarioDomainService : IDisposable
{
    Task<AuthorizationModel> AutenticarUsuarioAsync(string login, string senha);

    Task Adicionar(Usuario usuario);
    Task Atualizar(Usuario usuario);
    Task Remover(Guid id);

    Task<IEnumerable<Usuario>> ObterTodos();
    Task<Usuario> ObterPorLogin(string login);
    Task<Usuario> ObterPorId(Guid id);
}