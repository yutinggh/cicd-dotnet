using cicd_dotnet.Services;
using Xunit;

namespace UnitTests
{
    public class MathTests
    {
        [Fact]
        public void Add_TwoNumbers_ReturnsSum()
        {
            // Arrange
            var mathService = new MathService();
            var a = 5;
            var b = 3;

            // Act
            var result = mathService.Add(a, b);

            // Assert
            Assert.Equal(8, result);
        }

        [Fact]
        public void Multiply_TwoNumbers()
        {
            var mathService = new MathService();
            var a = 5;
            var b = 3;
            var result = mathService.Multiply(a, b);

            Assert.Equal(15, result);
        }
    }
}
