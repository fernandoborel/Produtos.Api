using Microsoft.AspNetCore.Mvc;
using Produtos.Application.Commands;
using Produtos.Application.Interfaces;

namespace Produtos.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class LoginController : ControllerBase
{
    private readonly IUsuarioAppService _usuarioAppService;

    public LoginController(IUsuarioAppService usuarioAppService)
    {
        _usuarioAppService = usuarioAppService;
    }

    [HttpPost("cadastrar")]
    public async Task<IActionResult> Post(CriarUsuarioCommand command)
    {
        await _usuarioAppService.Adicionar(command);
        return StatusCode(201, new
        {
            message = "Usuário cadastrado com sucesso!", command
        });
    }

    [HttpGet("obter-usuario/{id}")]
    public async Task<IActionResult> Get(Guid id)
    {
        var result = await _usuarioAppService.ObterPorId(id);
        return StatusCode(200, result);
    }

    [HttpPut("atualizar")]
    public async Task<IActionResult> Put(AlterarUsuarioCommand command)
    {
        await _usuarioAppService.Atualizar(command);
        return StatusCode(200, new
        {
            message = "Usuário atualizado com sucesso!", command
        });
    }

    [HttpDelete("excluir/{id}")]
    public async Task<IActionResult> Delete(Guid id)
    {
        await _usuarioAppService.Remover(id);
        return StatusCode(200, new
        {
            message = "Usuário excluído com sucesso!", id
        });
    }
}
