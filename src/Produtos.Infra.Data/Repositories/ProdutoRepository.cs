using Microsoft.EntityFrameworkCore;
using Produtos.Domain.Interfaces.Repositories;
using Produtos.Domain.Models;
using Produtos.Infra.Data.Contexts;

namespace Produtos.Infra.Data.Repositories;

public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
{
    private readonly SqlServerContext _context;

    public ProdutoRepository(SqlServerContext context) : base(context)
    {
        _context = context;
    }
    public async Task<IEnumerable<Produto>> GetByNameAsync(string name)
    {
        return await _context.Produtos.Where(p => p.Nome == name).ToListAsync();
    }

    public async Task<IEnumerable<Produto>> GetAtivo(int ativo)
    {
        return await _context.Produtos.Where(p => p.Ativo == ativo).ToListAsync();
    }


    public async Task<IEnumerable<Produto>> GetCategoriaAsync(string categoria)
    {
        return await _context.Produtos.Where(p => p.Categoria == categoria).ToListAsync();
    }
}
