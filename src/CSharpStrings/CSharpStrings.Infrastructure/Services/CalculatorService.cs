using CSharpStrings.Domain.Entities;
using CSharpStrings.Domain.Services;

namespace CSharpStrings.Infrastructure.Services
{
    public class CalculatorService : ICalculatorService
    {
        public int Calculate(CalculatorOptions options)
        {
            if (string.IsNullOrWhiteSpace(options.Numbers))
                return 0;

            var numberStrings = options.Numbers.Split(options.Delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries);

            // Convert to int and optionally limit
            var numbers = numberStrings
                .Take(options.MaxNumbers ?? int.MaxValue)
                .Select(x => int.TryParse(x, out var val) ? val : 0)
                .ToList();

            if (!options.AllowNegatives)
            {
                var negatives = numbers.Where(n => n < 0).ToList();
                if (negatives.Any())
                {
                    var negativesList = string.Join(", ", negatives);
                    throw new ArgumentException($"negatives not allowed: {negativesList}");
                }
            }

            // Respect ignore-above threshold
            var validNumbers = numbers.Where(n => n <= options.IgnoreAboveValue);
            return validNumbers.Sum();
        }
    }
}