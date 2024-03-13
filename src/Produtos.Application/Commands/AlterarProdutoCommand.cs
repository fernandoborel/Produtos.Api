using System.ComponentModel.DataAnnotations;

namespace Produtos.Application.Commands;

public class AlterarProdutoCommand
{
    public Guid Id { get; set; }

    [Required(ErrorMessage = "O campo Nome é obrigatório")]
    [Length(3, 100, ErrorMessage = "O campo Nome deve ter entre 3 e 100 caracteres")]
    public string Nome { get; set; }

    [Required(ErrorMessage = "O campo Preço é obrigatório")]
    public decimal Preco { get; set; }

    [Required(ErrorMessage = "O campo Categoria é obrigatório")]
    [Length(3, 100, ErrorMessage = "O campo Categoria deve ter entre 3 e 100 caracteres")]
    public string Categoria { get; set; }

    [Required(ErrorMessage = "O campo Quantidade é obrigatório")]
    public int Quantidade { get; set; }

    [Required(ErrorMessage = "O campo Ativo é obrigatório")]
    public int Ativo { get; set; }
}
