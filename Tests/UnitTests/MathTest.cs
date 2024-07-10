using cicd_dotnet.Services;
using Xunit;

namespace UnitTests
{
    public class MathTests
    {
        [Fact]
        public void Add_TwoNumbers()
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
        public void Subtract_TwoNumbers()
        {
            // Arrange
            var mathService = new MathService();
            var a = 5;
            var b = 3;

            // Act
            var result = mathService.Subtract(a, b);

            // Assert
            Assert.Equal(2, result);
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

        // [Fact]
        // public void Divide_TwoNumbers()
        // {
        //     // Arrange
        //     var mathService = new MathService();
        //     var a = 6;
        //     var b = 3;

        //     // Act
        //     var result = mathService.Divide(a, b);

        //     // Assert
        //     Assert.Equal(2, result);
        // }
    }
}
