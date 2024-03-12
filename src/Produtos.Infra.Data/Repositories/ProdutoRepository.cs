using Produtos.Domain.Models;
using Produtos.Domain.Interfaces.Repositories;
using Produtos.Infra.Data.Contexts;

namespace Produtos.Infra.Data.Repositories;

public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
{
    private readonly SqlServerContext _context;

    public ProdutoRepository(SqlServerContext context) : base(context)
    {
        _context = context;
    }
}
