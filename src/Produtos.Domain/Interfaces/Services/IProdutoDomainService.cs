using Produtos.Domain.Models;

namespace Produtos.Domain.Interfaces.Services;

public interface IProdutoDomainService : IDisposable
{
    Task Adicionar(Produto produto);
    Task Atualizar(Produto produto);
    Task Remover(Guid id);

    Task<IEnumerable<Produto>> ObterNome(string nome);
    Task<IEnumerable<Produto>> ObterCategoria(string categoria);
    Task<IEnumerable<Produto>> ObterAtivos(int ativo);

    Task<IEnumerable<Produto>> ObterTodos();

    Task<Produto> ObterPorId(Guid id);
}
