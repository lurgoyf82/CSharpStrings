using MediatR;
using CSharpStrings.Application.DTOs.Requests;
using CSharpStrings.Application.DTOs.Responses;

namespace CSharpStrings.Application.Handlers.StepFour
{
    public class GetStepFourRequestHandler : IRequestHandler<GetStepFourRequestDto, GetStepFourResponseDto>
    {
        public Task<GetStepFourResponseDto> Handle(GetStepFourRequestDto request, CancellationToken cancellationToken)
        {
            var response = new GetStepFourResponseDto();
            response.Sum = 0;

            try
            {
                if (!string.IsNullOrWhiteSpace(request.Numbers))
                {
                    var numbers = request.Numbers.Split(',', StringSplitOptions.RemoveEmptyEntries)
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