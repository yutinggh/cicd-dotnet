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
            Assert.Contains("Hello World!", responseString);
        }

        [Fact]
        public async Task Click_Button_OnHomePage_NavigatesToNewPage()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act: Request the home page
            var response = await client.GetAsync("/");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();

            // Print responseString for debugging
            System.Diagnostics.Debug.WriteLine("Home Page HTML: " + responseString);

            // Extract the button link from the response string
            var buttonLinkStartIndex = responseString.IndexOf("window.location.href='/") + "window.location.href='".Length;
            var buttonLinkEndIndex = responseString.IndexOf("'", buttonLinkStartIndex);
            var buttonLink = responseString.Substring(buttonLinkStartIndex, buttonLinkEndIndex - buttonLinkStartIndex);

            // Print buttonLink for debugging
            System.Diagnostics.Debug.WriteLine("Extracted Button Link: " + buttonLink);

            // Ensure the button link is correct
            Assert.False(string.IsNullOrEmpty(buttonLink), "Button link should not be null or empty.");

            // Navigate to the new page
            response = await client.GetAsync(buttonLink);

            // Assert
            response.EnsureSuccessStatusCode();
            responseString = await response.Content.ReadAsStringAsync();
            Assert.Equal("New Page", responseString);
        }
    }
}
