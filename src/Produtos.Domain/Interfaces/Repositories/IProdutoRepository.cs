using Produtos.Domain.Models;

namespace Produtos.Domain.Interfaces.Repositories;


public interface IProdutoRepository : IBaseRepository<Produto>
{
    Task<IEnumerable<Produto>> GetByNameAsync(string name);
    Task<IEnumerable<Produto>> GetCategoriaAsync(string categoria);
    Task<IEnumerable<Produto>> GetAtivo(int ativo);
}
