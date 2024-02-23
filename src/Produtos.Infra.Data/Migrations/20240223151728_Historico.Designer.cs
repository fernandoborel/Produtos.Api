﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Produtos.Infra.Data.Contexts;

#nullable disable

namespace Produtos.Infra.Data.Migrations
{
    [DbContext(typeof(SqlServerContext))]
    [Migration("20240223151728_Historico")]
    partial class Historico
    {
        /// <inheritdoc />
        protected override void BuildTargetModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "8.0.1")
                .HasAnnotation("Relational:MaxIdentifierLength", 128);

            SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder);

            modelBuilder.Entity("Historico", b =>
                {
                    b.Property<Guid>("idTransacao")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("IDTRANSACAO");

                    b.Property<Guid>("IdProduto")
                        .HasColumnType("uniqueidentifier");

                    b.Property<DateTime>("dataTransacao")
                        .HasColumnType("datetime2")
                        .HasColumnName("DATAALTERACAO");

                    b.Property<int>("novaQuantidade")
                        .HasColumnType("int")
                        .HasColumnName("QUANTIDADENOVA");

                    b.Property<decimal>("novoPreco")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("PRECONOVO");

                    b.Property<decimal>("precoAntigo")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("PRECOANTIGO");

                    b.Property<int>("quantidadeAntiga")
                        .HasColumnType("int")
                        .HasColumnName("QUANTIDADEANTIGA");

                    b.HasKey("idTransacao");

                    b.HasIndex("IdProduto");

                    b.ToTable("Historico", (string)null);
                });

            modelBuilder.Entity("Produtos.Domain.Models.Produto", b =>
                {
                    b.Property<Guid>("IdProduto")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("IDPRODUTO");

                    b.Property<DateTime>("DataCriacao")
                        .HasColumnType("datetime2")
                        .HasColumnName("DATACRIACAO");

                    b.Property<DateTime>("DataUltimaAlteracao")
                        .HasColumnType("datetime2")
                        .HasColumnName("DATAULTIMAALTERACAO");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("NOME");

                    b.Property<decimal>("Preco")
                        .HasColumnType("decimal(18,2)")
                        .HasColumnName("PRECO");

                    b.Property<int>("Quantidade")
                        .HasColumnType("int")
                        .HasColumnName("QUANTIDADE");

                    b.HasKey("IdProduto");

                    b.ToTable("Produto", (string)null);
                });

            modelBuilder.Entity("Produtos.Domain.Models.Usuario", b =>
                {
                    b.Property<Guid>("IdUsuario")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("uniqueidentifier")
                        .HasColumnName("IdUsuario");

                    b.Property<string>("Login")
                        .IsRequired()
                        .HasMaxLength(25)
                        .HasColumnType("nvarchar(25)")
                        .HasColumnName("Login");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasMaxLength(150)
                        .HasColumnType("nvarchar(150)")
                        .HasColumnName("Nome");

                    b.Property<string>("Senha")
                        .IsRequired()
                        .HasMaxLength(40)
                        .HasColumnType("nvarchar(40)")
                        .HasColumnName("Senha");

                    b.HasKey("IdUsuario");

                    b.ToTable("USUARIO", (string)null);
                });

            modelBuilder.Entity("Historico", b =>
                {
                    b.HasOne("Produtos.Domain.Models.Produto", "Produto")
                        .WithMany("Historicos")
                        .HasForeignKey("IdProduto")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Produto");
                });

            modelBuilder.Entity("Produtos.Domain.Models.Produto", b =>
                {
                    b.Navigation("Historicos");
                });
#pragma warning restore 612, 618
        }
    }
}
