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

        }
    }
}
