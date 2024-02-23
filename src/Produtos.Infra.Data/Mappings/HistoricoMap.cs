using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

public class HistoricoMap : IEntityTypeConfiguration<Historico>
{
    public void Configure(EntityTypeBuilder<Historico> builder)
    {
        builder.ToTable("Historico");

        builder.HasKey(h => h.idTransacao);

        builder.Property(h => h.idTransacao)
            .HasColumnName("IDTRANSACAO")
            .IsRequired();

        builder.Property(h => h.novoPreco)
            .HasColumnName("PRECONOVO")
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.Property(h => h.novaQuantidade)
            .HasColumnName("QUANTIDADENOVA")
            .IsRequired();

        builder.Property(h => h.precoAntigo)
            .HasColumnName("PRECOANTIGO")
            .HasColumnType("decimal(18,2)")
            .IsRequired();

        builder.Property(h => h.quantidadeAntiga)
            .HasColumnName("QUANTIDADEANTIGA")
            .IsRequired();

        builder.Property(h => h.dataTransacao)
            .HasColumnName("DATAALTERACAO")
            .HasColumnType("datetime2")
            .IsRequired();

        // Mapeando a relação com a entidade Produto
        builder.HasOne(h => h.Produto)
            .WithMany(p => p.Historicos)
            .HasForeignKey(h => h.IdProduto)
            .IsRequired()
            .OnDelete(DeleteBehavior.Cascade);
    }
}
