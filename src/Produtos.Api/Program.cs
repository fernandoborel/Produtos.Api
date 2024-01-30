using Produtos.Api.Configurations;
using Produtos.Api.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

#region Extensions

AutoMapperExtension.AddAutoMapper(builder);
CorsExtension.AddCors(builder);
EntityFrameworkExtension.AddEntityFramework(builder);
SwaggerExtension.AddSwagger(builder);

#endregion

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

CorsExtension.UseCors(app);

app.UseAuthorization();

app.MapControllers();

app.Run();