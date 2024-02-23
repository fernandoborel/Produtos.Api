using Produtos.Domain.Models;

public class Historico
{
    public Guid idTransacao { get; set; }
    public Guid IdProduto { get; set; }
    public decimal novoPreco { get; set; }
    public int novaQuantidade { get; set; }
    public decimal precoAntigo { get; set; }
    public int quantidadeAntiga { get; set; }
    public DateTime dataTransacao { get; set; } = DateTime.Now;


    // Relacionamento: um Histórico pertence a um único Produto
    public virtual Produto Produto { get; set; }
}