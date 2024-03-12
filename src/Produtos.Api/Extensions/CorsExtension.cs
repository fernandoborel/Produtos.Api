namespace Produtos.Api.Extensions;

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
