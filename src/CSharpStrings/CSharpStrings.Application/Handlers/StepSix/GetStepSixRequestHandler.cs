using MediatR;
using CSharpStrings.Application.DTOs.Requests;
using CSharpStrings.Application.DTOs.Responses;
using System.Text.RegularExpressions;

namespace CSharpStrings.Application.Handlers.StepSix
{
    public class GetStepSixRequestHandler : IRequestHandler<GetStepSixRequestDto, GetStepSixResponseDto>
    {
        public Task<GetStepSixResponseDto> Handle(GetStepSixRequestDto request, CancellationToken cancellationToken)
        {
            var response = new GetStepSixResponseDto();
            response.Sum = 0;

            try
            {
                if (!string.IsNullOrWhiteSpace(request.Numbers))
                {
                    string numbersToProcess = request.Numbers;
                    var delimiters = new List<string> { "," };

                    // Check for custom delimiter format: //[delim1][delim2]//
                    if (numbersToProcess.StartsWith("//[") && numbersToProcess.Contains("]//"))
                    {
                        var delimiterSection = numbersToProcess.Substring(0, numbersToProcess.IndexOf("]//") + 3);
                        numbersToProcess = numbersToProcess.Substring(delimiterSection.Length);

                        // Extract all delimiters between brackets
                        var delimiterMatches = Regex.Matches(delimiterSection, @"\[(.+?)\]");
                        foreach (Match match in delimiterMatches)
                        {
                            delimiters.Add(match.Groups[1].Value);
                        }
                    }

                    var numbers = numbersToProcess.Split(delimiters.ToArray(), StringSplitOptions.RemoveEmptyEntries)
                        .Select(n => int.TryParse(n, out var x) ? x : 0)
                        .ToList();

                    var negatives = numbers.Where(n => n < 0).ToList();
                    
                    if (negatives.Any())
                    {
                        var negativesList = string.Join(", ", negatives);
                        throw new ArgumentException($"negatives not allowed: {negativesList}");
                    }

                    // Ignore numbers bigger than 1000
                    var validNumbers = numbers.Where(n => n <= 1000);
                    response.Sum = validNumbers.Sum();
                }
            }
            catch (Exception ex)
            {
                response.Error = ex.Message;
            }

            return Task.FromResult(response);
        }
    }
}