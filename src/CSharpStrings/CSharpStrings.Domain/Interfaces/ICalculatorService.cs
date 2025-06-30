using CSharpStrings.Domain.Entities;

namespace CSharpStrings.Domain.Services
{
    public interface ICalculatorService
    {
        public int CalculateSum(string? input, CalculatorOptions options);


        // Restituisce i delimitatori custom separati dalla sezione con i numeri
        public (string delimiterSection, string numbersSection) SplitHeader(string? input);

        public List<int> ParseNumbersSection(string? numberSection, List<string> delimiters);

        public List<string> ParseDelimeterSection(string delimiterSection);

        public List<string> GetCustomDelimiters(string? input);


    }
}