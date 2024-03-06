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
            var produtoExistente = await _produtoRepository.GetAsync(produto.IdProduto);

            if (produtoExistente != null)
            {
                var historico = new Historico
                {
                    IdProduto = produto.IdProduto,
                    novoPreco = produto.Preco,
                    novaQuantidade = produto.Quantidade,
                    precoAntigo = produtoExistente.Preco,
                    quantidadeAntiga = produtoExistente.Quantidade
                };

                produtoExistente.Historicos.Add(historico);

                produtoExistente.Nome = produto.Nome;
                produtoExistente.Preco = produto.Preco;
                produtoExistente.Quantidade = produto.Quantidade;
                produtoExistente.DataUltimaAlteracao = DateTime.Now;

                await _produtoRepository.UpdateAsync(produtoExistente);
            }
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
