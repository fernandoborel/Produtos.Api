namespace Produtos.Domain.Interfaces.Services;

public interface IHistoricoDomainService : IDisposable
{
    Task Adicionar(Historico historico);
    Task Atualizar(Historico historico);
    Task Remover(Guid id);

    Task<IEnumerable<Historico>> ObterTodos();

    Task<Historico> ObterPorId(Guid id);
    Task<IEnumerable<Historico>> ObterPorProdutoId(Guid produtoId);
}
