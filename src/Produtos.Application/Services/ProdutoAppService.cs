using AutoMapper;
using Produtos.Application.Commands;
using Produtos.Application.Interfaces;
using Produtos.Domain.Interfaces.Services;
using Produtos.Domain.Models;

namespace Produtos.Application.Services;

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
        var foto = command.Foto?.OpenReadStream();

        var produto = new Produto
        {
            Nome = command.Nome,
            Preco = command.Preco,
            Quantidade = command.Quantidade,
            Foto = LerFotoComoArrayDeBytes(foto),
        };
        
        await _produtoDomainService.Adicionar(produto);
    }

    public async Task Atualizar(AlterarProdutoCommand command)
    {
        var produto = await _produtoDomainService.ObterPorId(command.Id);

        if (produto != null)
        {
            produto.Nome = command.Nome;
            produto.Preco = command.Preco;
            produto.Quantidade = command.Quantidade;

            await _produtoDomainService.Atualizar(produto);
        }
    }

    public async Task Remover(Guid id)
    {
        var produto = await _produtoDomainService.ObterPorId(id);
        if (produto != null)
        {
            await _produtoDomainService.Remover(id);
        }
    }

    public void Dispose()
    {
        _produtoDomainService.Dispose();
    }

    public async Task<Produto> ObterPorId(Guid id)
    {
        var produto = await _produtoDomainService.ObterPorId(id);
        return produto;
    }

    public async Task<IEnumerable<Produto>> ObterTodos()
    {
        var produtos = await _produtoDomainService.ObterTodos();
        return produtos;
    }

    private byte[] LerFotoComoArrayDeBytes(Stream fotoStream)
    {
        using (var memoryStream = new MemoryStream())
        {
            fotoStream?.CopyTo(memoryStream);
            return memoryStream.ToArray();
        }
    }

}
