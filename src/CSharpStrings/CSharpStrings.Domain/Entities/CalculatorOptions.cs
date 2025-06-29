namespace CSharpStrings.Domain.Entities
{
    public class CalculatorOptions
    {

        // Raw input string
        public string Numbers { get; set; } = string.Empty;

        // Custom delimiters (single or multiple, possibly longer than one char)
        public List<string> Delimiters { get; set; } = new() { "," };

        // Whether to allow negative numbers
        public bool AllowNegatives { get; set; } = true;

        // Ignore numbers bigger than this threshold (e.g., 1000)
        public int IgnoreAboveValue { get; set; } = 1000;

        // (Optional) Limit how many substrings can appear (e.g., for step 1)
        public int? MaxNumbers { get; set; }
    }
}