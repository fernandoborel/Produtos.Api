namespace Produtos.Api.Extensions
{
    /// <summary>
    /// Classe de extensão para o CORS no AspNet
    /// </summary>
    public class CorsExtension
    {
        public static void AddCors(WebApplicationBuilder builder)
        {
            builder.Services.AddCors(s => s.AddPolicy("DefaultPolicy",
                builder =>
                {
                    builder
                        .AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader();
                }));
        }

        public static void UseCors(WebApplication app)
        {
            app.UseCors("DefaultPolicy");
        }
    }
}
