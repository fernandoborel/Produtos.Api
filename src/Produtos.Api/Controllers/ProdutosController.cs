using Microsoft.AspNetCore.Mvc;
using Produtos.Application.Commands;
using Produtos.Application.Interfaces;

namespace Produtos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoAppService _produtoAppService;

        public ProdutosController(IProdutoAppService produtoAppService)
        {
            _produtoAppService = produtoAppService;
        }

        [HttpGet("obter-produtos")]
        public async Task<IActionResult> Get()
        {
            var result = await _produtoAppService.ObterTodos();
            return StatusCode(200, result);
        }

        [HttpPost("cadastrar")] // api/produtos/cadastrar
        public async Task<IActionResult> Post(CriarProdutoCommand command)
        {
            await _produtoAppService.Adicionar(command);
            return StatusCode(201, new
            {
                message = "Produto cadastrado com sucesso!", command
            });
        }
    }
}
