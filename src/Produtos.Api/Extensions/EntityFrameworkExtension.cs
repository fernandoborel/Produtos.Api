using Microsoft.EntityFrameworkCore;
using Produtos.Domain.Interfaces.Repositories;
using Produtos.Infra.Data.Contexts;
using Produtos.Infra.Data.Repositories;

namespace Produtos.Api.Configurations
{
    /// <summary>
    /// Classe de configuração do Entity Framework
    /// </summary>
    public static class EntityFrameworkExtension
    {
        public static void AddEntityFramework(WebApplicationBuilder builder)
        {
            var connectionString = builder.Configuration.GetConnectionString("ApiProdutos");

            builder.Services.AddDbContext<SqlServerContext>(options =>
            {
                options.UseSqlServer(connectionString);
            });

            builder.Services.AddTransient<IProdutoRepository, ProdutoRepository>();
        }
    }
}
