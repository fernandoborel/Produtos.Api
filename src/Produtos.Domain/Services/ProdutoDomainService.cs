using Produtos.Domain.Interfaces.Repositories;
using Produtos.Domain.Interfaces.Services;
using Produtos.Domain.Models;

namespace Produtos.Domain.Services
{
    public class ProdutoDomainService : IProdutoDomainService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoDomainService(IProdutoRepository produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public async Task Adicionar(Produto produto)
        {
            await _produtoRepository.AddAsync(produto);
        }

        public async Task Atualizar(Produto produto)
        {
            await _produtoRepository.UpdateAsync(produto);

        }

        public async Task Remover(Guid id)
        {
            var produto = await _produtoRepository.GetAsync(id);
            await _produtoRepository.DeleteAsync(produto);
        }

        public void Dispose()
        {
           _produtoRepository.Dispose();
        }

        public async Task<Produto> ObterPorId(Guid id)
        {
            var produto = await _produtoRepository.GetAsync(id);
            return produto;
        }

        public async Task<IEnumerable<Produto>> ObterTodos()
        {
            return await _produtoRepository.GetAllAsync();
        }
    }
}
