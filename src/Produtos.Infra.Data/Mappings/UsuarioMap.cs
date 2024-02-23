using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Produtos.Domain.Models;

namespace Produtos.Infra.Data.Mappings
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("USUARIO");

            builder.HasKey(x => x.IdUsuario);

            builder.Property(x => x.IdUsuario)
                .HasColumnName("IdUsuario");

            builder.Property(x => x.Nome)
                .HasColumnName("Nome")
                .HasMaxLength(150)
                .IsRequired();

            builder.Property(x => x.Login)
                .HasColumnName("Login")
                .HasMaxLength(25)
                .IsRequired();

            builder.Property(x => x.Senha)
                .HasColumnName("Senha")
                .HasMaxLength(40)
                .IsRequired();
        }
    }
}
