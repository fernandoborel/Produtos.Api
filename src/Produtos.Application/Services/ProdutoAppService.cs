using AutoMapper;
using Produtos.Application.Commands;
using Produtos.Application.Interfaces;
using Produtos.Domain.Interfaces.Services;
using Produtos.Domain.Models;

namespace Produtos.Application.Services
{
    public class ProdutoAppService : IProdutoAppService
    {
        private readonly IProdutoDomainService _produtoDomainService;
        private readonly IMapper _mapper;

        public ProdutoAppService(IProdutoDomainService produtoDomainService, IMapper mapper)
        {
            _produtoDomainService = produtoDomainService;
            _mapper = mapper;
        }

        public async Task Adicionar(CriarProdutoCommand command)
        {
            var usuario = _mapper.Map<Produto>(command);
            await _produtoDomainService.Adicionar(usuario);
        }

        public void Dispose()
        {
            _produtoDomainService.Dispose();
        }

        public async Task<IEnumerable<Produto>> ObterTodos()
        {
            var produtos = await _produtoDomainService.ObterTodos();
            return produtos;
        }
    }
}
