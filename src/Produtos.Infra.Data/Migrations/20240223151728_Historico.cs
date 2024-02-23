using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Produtos.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class Historico : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Historico",
                columns: table => new
                {
                    IDTRANSACAO = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    IdProduto = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PRECONOVO = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    QUANTIDADENOVA = table.Column<int>(type: "int", nullable: false),
                    PRECOANTIGO = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    QUANTIDADEANTIGA = table.Column<int>(type: "int", nullable: false),
                    DATAALTERACAO = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Historico", x => x.IDTRANSACAO);
                    table.ForeignKey(
                        name: "FK_Historico_Produto_IdProduto",
                        column: x => x.IdProduto,
                        principalTable: "Produto",
                        principalColumn: "IDPRODUTO",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Historico_IdProduto",
                table: "Historico",
                column: "IdProduto");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Historico");
        }
    }
}
