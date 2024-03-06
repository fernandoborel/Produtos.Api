namespace Produtos.Application.Commands;

public class AlterarHistoricoCommand
{
    public Guid IdProduto { get; set; }
    public decimal novoPreco { get; set; }
    public int novaQuantidade { get; set; }
    public decimal precoAntigo { get; set; }
    public int quantidadeAntiga { get; set; }
}
