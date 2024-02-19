using Bogus;
using FluentAssertions;
using Newtonsoft.Json;
using Produtos.Application.Commands;
using Produtos.Domain.Models;
using Produtos.Tests.Helpers;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using Xunit;

namespace Produtos.Tests.TestCases
{
    /// <summary>
    /// Classe de testes para a entidade Produtos.
    /// </summary>
    public class ProdutosTest
    {
        private readonly HttpClient _client;
        private readonly Faker _faker;

        public ProdutosTest()
        {
            _client = new HttpClient();

            #region Adicionando o token de autenticação

            var loginTest = new LoginTest();
            var response = loginTest.Post_Login_Returns_Ok().Result.Model.AccessToken;

            _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue
                ("Bearer", response);

            #endregion

            _faker = new Faker("pt_BR");
        }


        [Fact]
        public async Task <GetProdutoCommand>Post_Produtos_Return_Ok()
        {
            #region Criando os dados da requisição

            var request = new CriarProdutoCommand
            {
                Nome = _faker.Commerce.ProductName(),
                Preco = decimal.Parse(_faker.Commerce.Price()),
                Quantidade = 10
            };

            #endregion

            #region Executando os serviços da API

            var result = await _client.PostAsync
                ($"{ApiHelper.Endpoint}/produtos/cadastrar", ApiHelper.CreateContent(request));

            var response = ApiHelper.CreateResponse<GetProdutoCommand>(result);

            #endregion

            #region Validando os resultados

            result
                .StatusCode
                .Should()
                .Be(HttpStatusCode.Created);

            response.IdProduto.Should();
            response.Nome.Should();
            response.Preco.Should();
            response.Quantidade.Should();

            #endregion

            return response;
        }

        [Fact]
        public async Task Put_Produtos_Return_Ok()
        {
            #region Cadastrando um Produto

            var request = await Post_Produtos_Return_Ok();

            request.Nome = _faker.Commerce.ProductName();
            request.Preco = decimal.Parse(_faker.Commerce.Price());
            request.Quantidade = 20;

            #endregion

            #region Modificando os dados do Produto

            var result = await _client.PutAsync
                ($"{ApiHelper.Endpoint}/produtos/atualizar", ApiHelper.CreateContent(request));

            var response = ApiHelper.CreateResponse<GetProdutoCommand>(result);

            #endregion

            #region Validando os resultados

            result
                 .StatusCode
                 .Should()
                 .Be(HttpStatusCode.OK);

            response.IdProduto.Should();
            response.Nome.Should();
            response.Preco.Should();
            response.Quantidade.Should();

            #endregion
        }


        [Fact]
        public async Task Put_Produtos_Return_UnprocessableEntity()
        {
            #region Criando os dados da requisição

            var request = new AlterarProdutoCommand
            {
                Id = Guid.Parse("5E12A0F6-6AA0-497E-D5FA-08DC2C9DEC61"),
                Nome = "Feito à mão Queijo Coalho",
                Preco = decimal.Parse("300.92"),
                Quantidade = 20
            };

            #endregion

            #region Executando o serviço da API e capturando a resposta

            var result = await _client.PutAsync
                ($"{ApiHelper.Endpoint}/produtos/atualizar", ApiHelper.CreateContent(request));

            #endregion

            #region Validar o resultado do teste

            result
                .StatusCode
                .Should();

            #endregion
        }

        [Fact]
        public async Task Delete_Produtos_Return_Ok()
        {
            #region Executando o serviço da API e capturando a resposta

            var request = await Post_Produtos_Return_Ok();

            var result = await _client.DeleteAsync
                ($"{ApiHelper.Endpoint}/produtos/remover/{request.IdProduto}");

            var response = ApiHelper.CreateResponse<GetProdutoCommand>(result);

            #endregion

            #region Validar o resultado do teste

            result
                .StatusCode
                .Should()
                .Be(HttpStatusCode.OK);

            response.IdProduto.Should().Be(request.IdProduto);
            response.Nome.Should().Be(request.Nome);
            response.Preco.Should().Be(request.Preco);
            response.Quantidade.Should().Be(request.Quantidade);

            #endregion
        }

        [Fact]
        public async Task Delete_Produtos_Return_UnprocessableEntity()
        {
            #region Executando o serviço da API e capturando a resposta

            var result = await _client.DeleteAsync
                ($"{ApiHelper.Endpoint}/produtos/remover/{Guid.NewGuid()}");

            #endregion

            #region Validar o resultado do teste

            result
                .StatusCode
                .Should();

            #endregion
        }

        [Fact]
        public async Task GetAll_Produtos_Return_Ok()
        {
            #region Executando o serviço da API e capturando a resposta

            var request = await Post_Produtos_Return_Ok();

            var result = await _client.GetAsync($"{ApiHelper.Endpoint}/produtos/obter-produtos");
            var response = ApiHelper.CreateResponse<List<Produto>>(result);

            #endregion

            #region Validar o resultado do teste

            result
                .StatusCode
                .Should()
                .Be(HttpStatusCode.OK);

            response
                .Should()
                .NotBeEmpty();

            response
                .FirstOrDefault(res => res.IdProduto.Equals(request.IdProduto))
                .Should();

            #endregion
        }

        [Fact]
        public async Task GetById_Produtos_Return_Ok()
        {
            #region Executando o serviço da API e capturando a resposta

            var request = new Produto
            {
                IdProduto = Guid.Parse("5E12A0F6-6AA0-497E-D5FA-08DC2C9DEC61"),
                Nome = "Licenciado Congelado Frango",
                Preco = decimal.Parse("27.15"),
                Quantidade = 10
            };

            var result = await _client.GetAsync($"{ApiHelper.Endpoint}/produtos/obter-produto/{request.IdProduto}");
            var response = ApiHelper.CreateResponse<GetProdutoCommand>(result);

            #endregion

            #region Validar o resultado do teste

            result
                .StatusCode
                .Should()
                .Be(HttpStatusCode.OK);

            response.IdProduto.Should();
            response.Nome.Should();
            response.Preco.Should();
            response.Quantidade.Should();

            #endregion
        }
    }
}
