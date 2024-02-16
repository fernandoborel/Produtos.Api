using Produtos.Domain.Models;

namespace Produtos.Application.Commands;

public class AutenticarUsuarioResponse
{
    public string Message { get; set; }
    public AuthorizationModel Model { get; set; }
}