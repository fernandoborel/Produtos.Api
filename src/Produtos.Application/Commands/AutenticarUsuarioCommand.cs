using Produtos.Domain.Models;
using System.ComponentModel.DataAnnotations;

namespace Produtos.Application.Commands;

public class AutenticarUsuarioCommand
{
    [Required(ErrorMessage = "Por favor, informe o seu login.")]
    public string? Login { get; set; }

    [StringLength(20, MinimumLength = 6, ErrorMessage = "A senha deve ter no mínimo {2} caracteres e no máximo {1} caracteres")]
    [Required(ErrorMessage = "Por favor, informe a sua senha.")]
    public string? Senha { get; set; }
}