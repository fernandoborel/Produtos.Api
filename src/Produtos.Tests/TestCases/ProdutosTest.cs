using Bogus;
using FluentAssertions;
using Newtonsoft.Json;
using Produtos.Application.Commands;
using Produtos.Tests.Helpers;
using System.Net;
using System.Net.Http;
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
            _faker = new Faker("pt_BR");
        }


        [Fact]
        public async Task Post_Produtos_Return_Ok()
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

            var result = await _client.PostAsync($"{ApiHelper.Endpoint}/produtos/cadastrar", ApiHelper.CreateContent(request));
            
            #endregion

            #region Validando os resultados

            result.StatusCode.Should().Be(HttpStatusCode.Created);

            #endregion
        }

        [Fact]
        public async Task Put_Produtos_Return_Ok()
        {
            #region Cadastrando um Produto

            var createRequest = new CriarProdutoCommand
            {
                Nome = _faker.Commerce.ProductName(),
                Preco = decimal.Parse(_faker.Commerce.Price()),
                Quantidade = 10
            };

            var createResult = await _client.PostAsync($"{ApiHelper.Endpoint}/produtos/cadastrar", ApiHelper.CreateContent(createRequest));
            var createdProduct = ApiHelper.CreateResponse<GetProdutoCommand>(createResult);

            #endregion

            #region Modificando os dados do Produto

            var updateRequest = new AlterarProdutoCommand
            {
                Id = createdProduct.IdProduto,
                Nome = _faker.Commerce.ProductName(),
                Preco = decimal.Parse(_faker.Commerce.Price()),
                Quantidade = 20
            };

            var updateResult = await _client.PutAsync($"{ApiHelper.Endpoint}/produtos/atualizar", ApiHelper.CreateContent(updateRequest));
            var updatedProduct = ApiHelper.CreateResponse<GetProdutoCommand>(updateResult);

            #endregion

            #region Validando os resultados

            updateResult.StatusCode.Should().Be(HttpStatusCode.OK);

            updatedProduct.IdProduto.Should().Be(updateRequest.Id);
            updatedProduct.Nome.Should().Be(updateRequest.Nome);
            updatedProduct.Preco.Should().Be(updateRequest.Preco);
            updatedProduct.Quantidade.Should().Be(updateRequest.Quantidade);

            #endregion
        }


        [Fact(Skip = "Não implementado")]
        public void Put_Produtos_Return_UnprocessableEntity()
        {

        }

        [Fact(Skip = "Não implementado")]
        public void Delete_Produtos_Return_Ok()
        {

        }

        [Fact(Skip = "Não implementado")]
        public void Delete_Produtos_Return_UnprocessableEntity()
        {

        }

        [Fact(Skip = "Não implementado")]
        public void GetAll_Produtos_Return_Ok()
        {

        }

        [Fact(Skip = "Não implementado")]
        public void GetById_Produtos_Return_Ok()
        {

        }

        //01:35:00
    }
}
