using Produtos.Application.Commands;
using Produtos.Domain.Models;

namespace Produtos.Api.Extensions
{
    /// <summary>
    /// Classe para extensão do AutoMapper
    /// </summary>
    public class AutoMapperExtension
    {
        public static void AddAutoMapper(WebApplicationBuilder builder)
        {
            //configurar o AutoMapper
            builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            //configurar o mapeamento
            builder.Services.AddAutoMapper(cfg =>
            {
                cfg.CreateMap<CriarProdutoCommand, Produto>()
                    .AfterMap((src, dest) =>
                    {
                        dest.IdProduto = Guid.NewGuid();
                        dest.DataCriacao = DateTime.Now;
                        dest.DataUltimaAlteracao = DateTime.Now;
                    });
                
                cfg.CreateMap<Produto, GetProdutoCommand>()
                .AfterMap((src, dest) =>
                {
                        dest.Total = (src.Preco * src.Quantidade);
                });
            });
        }
    }
}
