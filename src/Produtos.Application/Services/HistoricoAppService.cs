using AutoMapper;
using Produtos.Application.Commands;
using Produtos.Application.Interfaces;
using Produtos.Domain.Interfaces.Services;

namespace Produtos.Application.Services;

public class HistoricoAppService : IHistoricoAppService
{
    private readonly IHistoricoDomainService _historicoDomainService;
    private readonly IMapper _mapper;

    public HistoricoAppService(IHistoricoDomainService historicoDomainService, IMapper mapper)
    {
        _historicoDomainService = historicoDomainService;
        _mapper = mapper;
    }

    public async Task Adicionar(CriarHistoricoCommand command)
    {
        var produto = _mapper.Map<Historico>(command);
        await _historicoDomainService.Adicionar(produto);
    }

    public async Task Atualizar(AlterarHistoricoCommand command)
    {
        var produto = await _historicoDomainService.ObterPorId(command.IdProduto);
        
        if (produto != null)
        {
            produto.novoPreco = command.novoPreco;
            produto.novaQuantidade = command.novaQuantidade;
            produto.precoAntigo = command.precoAntigo;
            produto.quantidadeAntiga = command.quantidadeAntiga;

            await _historicoDomainService.Atualizar(produto);
        }

    }

    public async Task Remover(Guid id)
    {
        var produto = await _historicoDomainService.ObterPorId(id);
        if (produto != null)
        {
           await _historicoDomainService.Remover(id);
        }
    }

    public void Dispose()
    {
        _historicoDomainService.Dispose();
    }

    public async Task<Historico> ObterPorId(Guid id)
    {
        var produto = await _historicoDomainService.ObterPorId(id);
        return produto;
    }

    public async Task<IEnumerable<Historico>> ObterTodos()
    {
        var produtos = await _historicoDomainService.ObterTodos();
        return produtos;
    }
}
