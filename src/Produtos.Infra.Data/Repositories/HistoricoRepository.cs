using Microsoft.EntityFrameworkCore;
using Produtos.Domain.Interfaces.Repositories;
using Produtos.Infra.Data.Contexts;

namespace Produtos.Infra.Data.Repositories;

public class HistoricoRepository : BaseRepository<Historico>, IHistoricoRepository
{
    private readonly SqlServerContext _context;

    public HistoricoRepository(SqlServerContext context) : base(context)
    {
        _context = context;
    }

    public async Task<IEnumerable<Historico>> GetByProdutoId(Guid produtoId)
    {
        return await _context.Historicos.Where(h => h.IdProduto == produtoId).ToListAsync();
    }
}