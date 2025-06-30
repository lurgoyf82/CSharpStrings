using CSharpStrings.Domain.Entities;

namespace CSharpStrings.Domain.Services
{
    public interface ICalculatorService
    {
        /// <summary>
        /// Parses the input string and returns a list of integers.
        /// </summary>
        /// <param name="input">The input string containing numbers.</param>
        /// <param name="delimiters">List of delimiters to use for splitting the input.</param>
        /// <returns>List of integers parsed from the input string.</returns>
        List<int> ParseInput(string numberString, List<string> delimiters);
        /// <summary>
        /// Validates the list of integers based on the options provided.
        /// </summary>
        /// <param name="numbers">List of integers to validate.</param>
        /// <param name="options">Options for validation such as allowing negatives and ignoring values above a threshold.</param>
        /// <returns>List of valid integers after applying the validation rules.</returns>
        List<int> ValidateNumbers(string? input, CalculatorOptions options);

        int CalculateSum(string? input, CalculatorOptions options);


        List<string> GetDelimiters(string? input);





    }
}