using Microsoft.AspNetCore.Mvc;
using Produtos.Application.Commands;
using Produtos.Application.Interfaces;
using Produtos.Domain.Models;

namespace Produtos.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class AuthController : ControllerBase
{
    private readonly IUsuarioAppService _usuarioAppService;

    public AuthController(IUsuarioAppService usuarioAppService) 
        => _usuarioAppService = usuarioAppService;

    [HttpPost("autenticar")]
    public async Task<IActionResult> Post(AutenticarUsuarioCommand command)
    {
        try
        {
            var usuario = await _usuarioAppService.AutenticarUsuarioAsync(command);

            var response = new AutenticarUsuarioResponse
            {
                Message = "Usuário autenticado com sucesso.",
                Model = new AuthorizationModel
                {
                    IdUsuario = usuario.IdUsuario,
                    Nome = usuario.Nome,
                    Login = usuario.Login,
                    DataHoraAcesso = usuario.DataHoraAcesso,
                    AccessToken = usuario.AccessToken
                }
            };

            return Ok(response);
        }
        catch (Exception e)
        {
            return StatusCode(500, e.Message);
        }
    }
}