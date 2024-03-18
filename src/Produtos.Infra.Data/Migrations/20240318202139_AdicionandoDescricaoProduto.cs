using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Produtos.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AdicionandoDescricaoProduto : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "DESCRICAO",
                table: "Produto",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: false,
                defaultValue: "");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "DESCRICAO",
                table: "Produto");
        }
    }
}
