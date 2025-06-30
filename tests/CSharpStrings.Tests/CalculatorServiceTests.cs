using CSharpStrings.Domain.Entities;
using CSharpStrings.Infrastructure.Services;
using Xunit;

namespace CSharpStrings.Tests
{
    public class CalculatorServiceTests
    {
        [Theory]
        [InlineData("", 0)]
        [InlineData("1", 1)]
        [InlineData("1,2", 3)]
        public void StepOne_SumsBasicNumbers(string input, int expected)
        {
            var options = new CalculatorOptions
            {
                Delimiters = new List<string> { "," },
                AllowMultipleDelimeters = false,
                MaxDelimeterSize = 0,
                MaxNumbers = 3,
                AllowNegatives = true,
                IgnoreAboveOrEqual = 0
            };

            var service = new CalculatorService();
            var result = service.CalculateSum(input, options);

            Assert.Equal(expected, result);
        }
    }
}
