namespace Produtos.Application.Commands;

public class CriarHistoricoCommand
{
    public Guid IdProduto { get; set; }
    public string NomeProduto { get; set; }
    public decimal Preco { get; set; }
    public DateTime DataAlteracao { get; set; }
    public int Quantidade { get; set; }
}
