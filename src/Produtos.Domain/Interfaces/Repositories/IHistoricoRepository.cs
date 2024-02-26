namespace Produtos.Domain.Interfaces.Repositories;

public interface IHistoricoRepository : IBaseRepository<Historico>
{
    Task<IEnumerable<Historico>> GetByProdutoId(Guid produtoId);
}
