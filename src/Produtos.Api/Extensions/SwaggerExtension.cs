using Microsoft.OpenApi.Models;

namespace Produtos.Api.Extensions
{
    /// <summary>
    /// Classe de configuração para o Swagger
    /// </summary>
    public static class SwaggerExtension
    {
        public static void AddSwagger(WebApplicationBuilder builder)
        {
            builder.Services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc("v1", new OpenApiInfo
                {
                    Title = "Produtos API",
                    Version = "v1",
                    Description = "API de Produtos",
                    Contact = new OpenApiContact
                    {
                        Name = "Fernando Borel",
                        Email = "fernandomenezesborel@gmail.com",
                        Url = new Uri("https://github.com/fernandoborel")
                    }
                });
            });
        }
    }
}
