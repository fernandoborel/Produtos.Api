using Produtos.Domain.Interfaces.Repositories;
using Produtos.Domain.Interfaces.Services;

namespace Produtos.Domain.Services;

public class HistoricoDomainService : IHistoricoDomainService
{
    private readonly IHistoricoRepository _historicoRepository;

    public HistoricoDomainService(IHistoricoRepository historicoRepository)
    {
        _historicoRepository = historicoRepository;
    }

    public async Task Adicionar(Historico historico)
    {
        await _historicoRepository.AddAsync(historico);
    }

    public async Task Atualizar(Historico historico)
    {
        await _historicoRepository.UpdateAsync(historico);
    }

    public async Task Remover(Guid id)
    {
        var produto = await _historicoRepository.GetAsync(id);
        await _historicoRepository.DeleteAsync(produto);
    }

    public void Dispose()
    {
        _historicoRepository.Dispose();
    }

    public async Task<Historico> ObterPorId(Guid id)
    {
        var historico = await _historicoRepository.GetAsync(id);
        return historico;
    }

    public async Task<IEnumerable<Historico>> ObterPorProdutoId(Guid produtoId)
    {
        var historico = await _historicoRepository.GetByProdutoId(produtoId);
        return historico;
    }

    public async Task<IEnumerable<Historico>> ObterTodos()
    {
        return await _historicoRepository.GetAllAsync();
    }
}
