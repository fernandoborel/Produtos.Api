using Produtos.Application.Commands;

namespace Produtos.Application.Interfaces;

public interface IHistoricoAppService : IDisposable
{
    Task Adicionar(CriarHistoricoCommand command);
    Task Atualizar(AlterarHistoricoCommand command);
    Task Remover(Guid id);

    Task<IEnumerable<Historico>> ObterTodos();
    Task<Historico> ObterPorId(Guid id);
}
