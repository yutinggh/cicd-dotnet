using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace EndToEndTests
{
    public class EndToEndTests : IClassFixture<WebApplicationFactory<cicd_dotnet.Program>>
    {
        private readonly WebApplicationFactory<cicd_dotnet.Program> _factory;

        public EndToEndTests(WebApplicationFactory<cicd_dotnet.Program> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task Get_HomePage_ReturnsHelloWorld()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("/");

            // Assert
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();
            Assert.Equal("Hello World!", responseString);
        }
    }
}
