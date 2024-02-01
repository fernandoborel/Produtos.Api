﻿namespace Produtos.Domain.Models
{
    public class Produto
    {
        public Guid IdProduto { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.Now;
        public DateTime DataUltimaAlteracao { get; set; } = DateTime.Now;
    }
}
