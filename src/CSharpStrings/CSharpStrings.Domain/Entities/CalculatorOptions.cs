namespace CSharpStrings.Domain.Entities
{
    public class CalculatorOptions
    {
        // Custom delimiters (single or multiple, possibly longer than one char)
        public List<string>? Delimiters { get; set; } = null;

        // Whether to allow multiple delimiters
        public bool AllowMultipleDelimeters { get; set; } = true;

        // Maximum allower length of a delimiter
        public int MaxDelimeterSize { get; set; } = 1;

        // Maximum quantity of numbers allowed
        public int MaxNumbers { get; set; } = 0;

        // Whether to allow negative numbers
        public bool AllowNegatives { get; set; } = true;

        // Ignore numbers bigger than this threshold (e.g., 1000)
        public int IgnoreAboveValue { get; set; } = 0;
    }
}