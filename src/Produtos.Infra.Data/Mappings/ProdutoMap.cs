﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Produtos.Domain.Models;

public class ProdutoMap : IEntityTypeConfiguration<Produto>
{
    public void Configure(EntityTypeBuilder<Produto> builder)
    {
        builder.ToTable("Produto");

        builder.HasKey(p => p.IdProduto);

        builder.Property(p => p.IdProduto)
            .HasColumnName("IDPRODUTO")
            .IsRequired();

        builder.Property(p => p.Nome)
            .HasColumnName("NOME")
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(p => p.Preco)
            .HasColumnName("PRECO")
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.Property(p => p.Descricao)
            .HasColumnName("DESCRICAO")
            .HasMaxLength(500)
            .IsRequired();

        builder.Property(p => p.Categoria)
            .HasColumnName("CATEGORIA")
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(p => p.Quantidade)
            .HasColumnName("QUANTIDADE")
            .IsRequired();

        builder.Property(p => p.Ativo)
            .HasColumnName("ATIVO")
            .HasDefaultValue(1)  // Definindo o valor padrão como 1
            .IsRequired();

        builder.Property(p => p.DataCriacao)
            .HasColumnName("DATACRIACAO")
            .HasColumnType("datetime2")
            .IsRequired();

        builder.Property(p => p.DataUltimaAlteracao)
            .HasColumnName("DATAULTIMAALTERACAO")
            .HasColumnType("datetime2")
            .IsRequired();

        builder.Property(p => p.Foto)
            .HasColumnName("FOTO")
            .IsRequired(false);

        // Mapeando a relação com a entidade Historico
        builder.HasMany(p => p.Historicos)
            .WithOne(h => h.Produto)
            .HasForeignKey(h => h.IdProduto)
            .IsRequired();

        // Configurando o comportamento de exclusão em cascata para a relação com Históricos
        builder.HasMany(p => p.Historicos)
            .WithOne(h => h.Produto)
            .HasForeignKey(h => h.IdProduto)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
}
