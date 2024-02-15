using Microsoft.AspNetCore.Mvc;
using Produtos.Application.Interfaces;
using Produtos.Infra.Data.Utils;

namespace Produtos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IUsuarioAppService _usuarioAppService;

        public AuthController(IUsuarioAppService usuarioAppService)
        {
            _usuarioAppService = usuarioAppService;
        }

        [HttpPost("autenticar")]
        public async Task<IActionResult> Post(string login, string senha)
        {
            var senhaCriptografada = MD5Util.Get(senha);

            await _usuarioAppService.ObterPorLogin(login, senhaCriptografada);
            return StatusCode(201, new
            {
                message = "Usuário autenticado com sucesso!",
            });
        }
    }
}
