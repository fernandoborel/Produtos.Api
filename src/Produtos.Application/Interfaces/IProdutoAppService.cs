using Produtos.Application.Commands;

namespace Produtos.Application.Interfaces
{
    public interface IProdutoAppService : IDisposable
    {
        Task Adicionar(CriarProdutoCommand command);
        //Task Atualizar(Produto produto);
        //Task Remover(Guid id);

        //Task<IEnumerable<Produto>> ObterTodos();
        //Task<Produto> ObterPorId(Guid id);
    }
}
