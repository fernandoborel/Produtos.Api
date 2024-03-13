using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Produtos.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AlterandoProdutos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ATIVO",
                table: "Produto",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.AddColumn<string>(
                name: "CATEGORIA",
                table: "Produto",
                type: "nvarchar(150)",
                maxLength: 150,
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_USUARIO_Login",
                table: "USUARIO",
                column: "Login",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_USUARIO_Login",
                table: "USUARIO");

            migrationBuilder.DropColumn(
                name: "ATIVO",
                table: "Produto");

            migrationBuilder.DropColumn(
                name: "CATEGORIA",
                table: "Produto");
        }
    }
}
