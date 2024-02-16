namespace Produtos.Domain.Models;

/// <summary>
/// Modelo de dados para o retorno da autenticação do usuário
/// </summary>
public class AuthorizationModel
{
    public Guid IdUsuario { get; set; }
    public string? Nome { get; set; }
    public string? Login { get; set; }
    public DateTime DataHoraAcesso { get; set; }
    public string? AccessToken { get; set; }
}