using Produtos.Application.Commands;
using Produtos.Domain.Models;

namespace Produtos.Application.Interfaces;

public interface IUsuarioAppService : IDisposable
{
    Task Adicionar(CriarUsuarioCommand command);
    Task Atualizar(AlterarUsuarioCommand command);
    Task Remover(Guid id);

    Task<IEnumerable<Usuario>> ObterTodos();
    Task<Usuario> ObterPorId(Guid id);
    Task<AuthorizationModel> AutenticarUsuarioAsync(AutenticarUsuarioCommand command);
}