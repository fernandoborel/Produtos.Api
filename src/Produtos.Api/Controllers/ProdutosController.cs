using Microsoft.AspNetCore.Mvc;

namespace Produtos.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok("Lista de produtos");
        }
    }
}
