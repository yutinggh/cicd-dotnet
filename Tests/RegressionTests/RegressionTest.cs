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
        public async Task Click_Button_GoToCalculator_ShowsCalculatorPage()
        {
            // Arrange
            var client = _factory.CreateClient();

            // Act: Request the home page
            var response = await client.GetAsync("/");
            response.EnsureSuccessStatusCode();
            var responseString = await response.Content.ReadAsStringAsync();

            // Extract the button link from the response string
            var buttonLinkStartIndex = responseString.IndexOf("window.location.href='/") + "window.location.href='".Length;
            var buttonLinkEndIndex = responseString.IndexOf("'", buttonLinkStartIndex);
            var buttonLink = responseString.Substring(buttonLinkStartIndex, buttonLinkEndIndex - buttonLinkStartIndex);

            // Navigate to the calculator page
            response = await client.GetAsync(buttonLink);
            response.EnsureSuccessStatusCode();

            // Assert: Verify that we are on the calculator page
            var calculatorResponseString = await response.Content.ReadAsStringAsync();
            Assert.Contains("Calculator", calculatorResponseString);

            // Act: Enter numbers and calculate
            var formData = new System.Net.Http.FormUrlEncodedContent(new[]
            {
                new KeyValuePair<string, string>("Number1", "5"),
                new KeyValuePair<string, string>("Number2", "2"),
                new KeyValuePair<string, string>("Operation", "Add")
            });

            response = await client.PostAsync("/Home/Calculate", formData);
            response.EnsureSuccessStatusCode();

            // Assert: Verify the result
            var resultResponseString = await response.Content.ReadAsStringAsync();
            Assert.Contains("Result: 7", resultResponseString);
        }
    }
}
