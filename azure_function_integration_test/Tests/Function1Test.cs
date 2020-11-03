using System.Net;
using System.Net.Http;
using Xunit;

namespace azure_function_integration_test.Tests
{
    [Collection(nameof(FunctionTestCollection))]
    public class Function1Test : BaseTest
    {
        [Fact]
        public async void HttpGetTest()
        {
            HttpClient client = new HttpClient { BaseAddress = Endpoint };

            var response = await client.GetAsync("api/Function1?name=Wayne");

            //Deu ok na requisição?
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }

        [Fact]
        public async void HttpPostTest()
        {
            HttpClient client = new HttpClient { BaseAddress = Endpoint };

            var response = await client.PostAsJsonAsync("api/Function1", new { name = "Damian" } );

            //Deu ok na requisição?
            Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        }
    }
}
