using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Produtos.Application.Commands;
using Produtos.Application.Interfaces;

namespace Produtos.Api.Controllers;

[Authorize]
[Route("api/[controller]")]
[ApiController]
public class ProdutosController : ControllerBase
{
    private readonly IProdutoAppService _produtoAppService;

    public ProdutosController(IProdutoAppService produtoAppService)
    {
        _produtoAppService = produtoAppService;
    }

    #region Get

    [HttpGet("obter-produtos")]
    public async Task<IActionResult> Get()
    {
        var result = await _produtoAppService.ObterTodos();
        return StatusCode(200, result);
    }


    [HttpGet("obter-produto/{id}")] // api/produtos/obter-produto/{id}
    public async Task<IActionResult> Get(Guid id)
    {
        var result = await _produtoAppService.ObterPorId(id);
        return StatusCode(200, result);
    }

    [HttpGet("obter-por-nome/{nome}")] // api/produtos/obter-por-nome/{nome}
    public async Task<IActionResult> GetByName(string nome)
    {
        var result = await _produtoAppService.ObterPorNome(nome);
        return StatusCode(200, result);
    }

    [HttpGet("obter-por-categoria/{categoria}")] // api/produtos/obter-por-categoria/{categoria}
    public async Task<IActionResult> Get(string categoria)
    {
        var result = await _produtoAppService.ObterPorCategoria(categoria);
        return StatusCode(200, result);
    }

    [HttpGet("obter-por-ativo/{ativo}")] // api/produtos/obter-por-ativo/{ativo}
    public async Task<IActionResult> Get(int ativo)
    {
        var result = await _produtoAppService.ObterPorAtivo(ativo);
        return StatusCode(200, result);
    }

    #endregion


    [HttpPost("cadastrar")] // api/produtos/cadastrar
    public async Task<IActionResult> Post(CriarProdutoCommand command)
    {
        await _produtoAppService.Adicionar(command);
        return StatusCode(201, new
        {
            message = "Produto cadastrado com sucesso!", command
        });
    }


    [HttpPut("atualizar")] // api/produtos/atualizar
    public async Task<IActionResult> Put(AlterarProdutoCommand command)
    {
        await _produtoAppService.Atualizar(command);
        return StatusCode(200, new
        {
            message = "Produto atualizado com sucesso!", command
        });
    }


    [HttpDelete("remover/{id}")] // api/produtos/remover/{id}
    public async Task<IActionResult> Delete(Guid id)
    {
        await _produtoAppService.Remover(id);
        return StatusCode(200, new
        {
            message = "Produto removido com sucesso!", id
        });
    }
}
