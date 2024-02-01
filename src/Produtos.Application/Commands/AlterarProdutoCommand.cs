namespace Produtos.Application.Commands
{
    public class AlterarProdutoCommand
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
    }
}
