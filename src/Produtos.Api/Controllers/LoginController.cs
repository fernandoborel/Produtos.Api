using Microsoft.AspNetCore.Mvc;
using Produtos.Application.Commands;
using Produtos.Application.Interfaces;

namespace Produtos.Api.Controllers
{
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
    }
}
