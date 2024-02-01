using Produtos.Application.Commands;
using Produtos.Domain.Models;

namespace Produtos.Application.Interfaces
{
    public interface IProdutoAppService : IDisposable
    {
        Task Adicionar(CriarProdutoCommand command);
        Task Atualizar(AlterarProdutoCommand command);
        Task Remover(Guid id);

        Task<IEnumerable<Produto>> ObterTodos();
        Task<Produto> ObterPorId(Guid id);
    }
}
