using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Produtos.Application.Commands;

public class CriarUsuarioCommand
{
    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [Length(3, 100, ErrorMessage = "O campo {0} deve ter entre 3 e 100 caracteres")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [Length(3, 100, ErrorMessage = "O campo {0} deve ter entre 3 e 100 caracteres")]
    public string Login { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [Length(3, 100, ErrorMessage = "O campo {0} deve ter entre 3 e 100 caracteres")]
    public string Senha { get; set; }

    [Required(ErrorMessage = "O campo Foto é obrigatório")]
    public IFormFile Foto { get; set; }
}
