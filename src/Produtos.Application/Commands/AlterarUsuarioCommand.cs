using System.ComponentModel.DataAnnotations;

namespace Produtos.Application.Commands;

public class AlterarUsuarioCommand
{
    public Guid Id { get; set; }

    [Required(ErrorMessage = "O campo Nome é obrigatório")]
    [Length(3, 100, ErrorMessage = "O campo Nome deve ter entre 3 e 100 caracteres")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "O campo {0} é obrigatório")]
    [EmailAddress(ErrorMessage = "O campo {0} deve ser um endereço de email válido")]
    public string Login { get; set; }

    [Required(ErrorMessage = "O campo Senha é obrigatório")]
    [Length(6, 20, ErrorMessage = "O campo Senha deve ter entre 6 e 20 caracteres")]
    public string Senha { get; set; }
}
