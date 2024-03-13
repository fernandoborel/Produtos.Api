namespace Produtos.Domain.Models;

public class Produto
{
    public Guid IdProduto { get; set; }
    public string Nome { get; set; }
    public decimal Preco { get; set; }
    public string Categoria { get; set; }
    public int Quantidade { get; set; }
    public int Ativo { get; set; } = 1;
    public DateTime DataCriacao { get; set; } = DateTime.Now;
    public DateTime DataUltimaAlteracao { get; set; } = DateTime.Now;

    public byte[] Foto { get; set; }

    // Relacionamento: um Produto pode ter vários Históricos
    public virtual ICollection<Historico> Historicos { get; set; } = new List<Historico>();
}