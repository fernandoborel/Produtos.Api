using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Produtos.Infra.Data.Migrations
{
    /// <inheritdoc />
    public partial class AdicionandoFotoAoUsuario : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<byte[]>(
                name: "FOTO",
                table: "USUARIO",
                type: "varbinary(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "FOTO",
                table: "USUARIO");
        }
    }
}
