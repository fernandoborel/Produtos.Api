using FluentAssertions;
using Produtos.Application.Commands;
using Produtos.Tests.Helpers;
using System.Net;
using Xunit;

namespace Produtos.Tests.TestCases;

public class LoginTest
{
    private readonly HttpClient _client;

    public LoginTest()
    {
        _client = new HttpClient();
    }

    [Fact]
    public async Task<AutenticarUsuarioResponse> Post_Login_Returns_Ok()
    {
        #region Criando os dados da requisição

        var request = new AutenticarUsuarioCommand
        {
            Login = "cicerocesar",
            Senha = "Tor71660"
        };

        #endregion

        #region Executando os serviços da API

        var result = await _client.PostAsync
            ($"{ApiHelper.Endpoint}/auth/autenticar", ApiHelper.CreateContent(request));

        var response = ApiHelper.CreateResponse<AutenticarUsuarioResponse>(result);

        #endregion

        #region Validando os resultados

        result
            .StatusCode
            .Should()
            .Be(HttpStatusCode.OK);

        #endregion

        return response;

    }

    [Fact]
    public async Task Post_Login_Returns_Unauthorized()
    {
        #region Criando os dados da requisição

        var request = new AutenticarUsuarioCommand
        {
            Login = "testeABC",
            Senha = "@TesteABC"
        };

        #endregion

        #region Executando os serviços da API

        var result = await _client.PostAsync
            ($"{ApiHelper.Endpoint}/auth/autenticar", ApiHelper.CreateContent(request));

        #endregion

        #region Validando os resultados

        result
            .StatusCode
            .Should();

        #endregion
    }

}
