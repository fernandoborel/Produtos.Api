using Bogus;
using FluentAssertions;
using Newtonsoft.Json;
using Produtos.Application.Commands;
using Produtos.Tests.Helpers;
using System.Net;
using System.Text;
using Xunit;

namespace Produtos.Tests.TestCases
{
    /// <summary>
    /// Classe de testes para a entidade Produtos.
    /// </summary>
    public class ProdutosTest
    {
        [Fact]
        public async Task Post_Produtos_Return_Ok()
        {
            var faker = new Faker("pt_BR");

            #region Requisição

            var request = new CriarProdutoCommand
            {
                Nome = faker.Commerce.ProductName(),
                Preco = decimal.Parse(faker.Commerce.Price()),
                Quantidade = 10
            };

            var content = new StringContent(JsonConvert.SerializeObject(request),
                    Encoding.UTF8, "application/json");

            #endregion

            #region Teste

            var client = new HttpClient();
            var response = await client.PostAsync($"{ApiHelper.Endpoint}/produtos/cadastrar", content);

            #endregion

            #region Validação

            response.StatusCode.Should().Be(HttpStatusCode.Created,
                $"Esperado: HttpStatusCode.Created (201). Encontrado: {response.StatusCode}. Conteúdo da resposta: {await response.Content.ReadAsStringAsync()}");


            #endregion
        }

        [Fact(Skip = "Não implementado")]
        public void Put_Produtos_Return_Ok()
        {

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
