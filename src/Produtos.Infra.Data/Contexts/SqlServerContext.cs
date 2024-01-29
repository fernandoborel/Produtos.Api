using Microsoft.EntityFrameworkCore;
using Produtos.Domain.Models;
using Produtos.Infra.Data.Mappings;

namespace Produtos.Infra.Data.Contexts
{
    /// <summary>
    /// Classe para acesso ao banco de dados com o Entity Framework Core
    /// </summary>
    public class SqlServerContext : DbContext
    {
        public SqlServerContext(DbContextOptions<SqlServerContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //classe de mapeamento
            modelBuilder.ApplyConfiguration(new ProdutoMap());
        }

        public DbSet<Produto> Produtos { get; set; }
    }
}
