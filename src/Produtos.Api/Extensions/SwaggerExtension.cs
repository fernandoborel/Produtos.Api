using Microsoft.OpenApi.Models;

namespace Produtos.Api.Extensions;

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
            s.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            {
                Description = "Cabeçalho de autorização JWT usando o esquema Bearer. Examplo: \"Authorization: Bearer {token}\"",
                Name = "Authorization",
                In = ParameterLocation.Header,
                Type = SecuritySchemeType.ApiKey,
                Scheme = "Bearer"
            });

            s.AddSecurityRequirement(new OpenApiSecurityRequirement
            {
                {
                    new OpenApiSecurityScheme
                    {
                        Reference = new OpenApiReference
                        {
                            Type = ReferenceType.SecurityScheme,
                            Id = "Bearer"
                        },
                        Scheme = "oauth2",
                        Name = "Bearer",
                        In = ParameterLocation.Header,
                    },
                    new List<string>()
                }
            });
        });
    }
}