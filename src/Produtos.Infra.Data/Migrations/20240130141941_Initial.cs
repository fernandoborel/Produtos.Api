using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Produtos.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produto",
                columns: table => new
                {
                    IDPRODUTO = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    NOME = table.Column<string>(type: "nvarchar(150)", maxLength: 150, nullable: false),
                    PRECO = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    QUANTIDADE = table.Column<int>(type: "int", nullable: false),
                    DATACRIACAO = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DATAULTIMAALTERACAO = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produto", x => x.IDPRODUTO);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produto");
        }
    }
}
