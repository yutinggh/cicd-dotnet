using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc.Testing;
using Xunit;

namespace Tests
{
    public class ProgramTests : IClassFixture<WebApplicationFactory<ProgramTests>> // Adjusted namespace
    {
        private readonly WebApplicationFactory<ProgramTests> _factory;

        public ProgramTests(WebApplicationFactory<ProgramTests> factory)
        {
            _factory = factory;
        }

        [Fact]
        public async Task GetRoot_ReturnsHelloWorld()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act
            var response = await client.GetAsync("/");

            // Assert
            response.EnsureSuccessStatusCode(); // Status Code 200-299
            var responseString = await response.Content.ReadAsStringAsync();
            Assert.Equal("Hello World!", responseString);
        }
    }
}
