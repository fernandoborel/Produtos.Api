using Newtonsoft.Json;
using System.Text;

namespace Produtos.Tests.Helpers;

public class ApiHelper
{
    /// <summary>
    /// Endereço da API.
    /// </summary>
    public static string Endpoint
    {
        get => "http://produtosapi2024-001-site1.ftempurl.com/api";
    }

    /// <summary>
    /// Cria um conteúdo JSON para requisição.
    /// </summary>
    public static StringContent CreateContent<TRequest>(TRequest request) where TRequest : class
    {
        return new StringContent(JsonConvert.SerializeObject(request),
                               Encoding.UTF8, "application/json");
    }

    /// <summary>
    /// Deserializa a resposta da requisição.
    /// </summary>
    public static TResponse CreateResponse<TResponse>(HttpResponseMessage message) where TResponse : class
    {
        return JsonConvert.DeserializeObject<TResponse>(message.Content.ReadAsStringAsync().Result);
    }
}
