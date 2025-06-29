using MediatR;
using CSharpStrings.Application.DTOs.Requests;
using CSharpStrings.Application.DTOs.Responses;
using System.Text.RegularExpressions;

namespace CSharpStrings.Application.Handlers.StepFive
{
    public class GetStepFiveRequestHandler : IRequestHandler<GetStepFiveRequestDto, GetStepFiveResponseDto>
    {
        public Task<GetStepFiveResponseDto> Handle(GetStepFiveRequestDto request, CancellationToken cancellationToken)
        {
            var response = new GetStepFiveResponseDto();
            response.Sum = 0;

            try
            {
                if (!string.IsNullOrWhiteSpace(request.Numbers))
                {
                    string numbersToProcess = request.Numbers;
                    string[] delimiters = { "," };

                    // Check for custom delimiter format: //[delimiter]//
                    if (numbersToProcess.StartsWith("//[") && numbersToProcess.Contains("]//"))
                    {
                        var delimiterMatch = Regex.Match(numbersToProcess, @"^//\[(.+?)\]//(.*)$");
                        if (delimiterMatch.Success)
                        {
                            string customDelimiter = delimiterMatch.Groups[1].Value;
                            numbersToProcess = delimiterMatch.Groups[2].Value;
                            delimiters = new[] { ",", customDelimiter };
                        }
                    }

                    var numbers = numbersToProcess.Split(delimiters, StringSplitOptions.RemoveEmptyEntries)
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