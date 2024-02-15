using Produtos.Api.Configurations;
using Produtos.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

//caixa baixa nas rotas
builder.Services.AddRouting(options => options.LowercaseUrls = true);

#region Extensions

SwaggerExtension.AddSwagger(builder);
EntityFrameworkExtension.AddEntityFramework(builder);
AutoMapperExtension.AddAutoMapper(builder);
CorsExtension.AddCors(builder);
JwtConfiguration.AddJwt(builder);

#endregion

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

CorsExtension.UseCors(app);

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();

//produtosapi2024-001