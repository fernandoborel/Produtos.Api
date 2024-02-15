using Microsoft.EntityFrameworkCore;
using Produtos.Application.Interfaces;
using Produtos.Application.Services;
using Produtos.Domain.Interfaces.Repositories;
using Produtos.Domain.Interfaces.Services;
using Produtos.Domain.Services;
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
            builder.Services.AddTransient<IProdutoAppService, ProdutoAppService>();
            builder.Services.AddTransient<IProdutoDomainService, ProdutoDomainService>();


            builder.Services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            builder.Services.AddTransient<IUsuarioAppService, UsuarioAppService>();
            builder.Services.AddTransient<IUsuarioDomainService, UsuarioDomainService>();
        }
    }
}
