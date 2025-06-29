using MediatR;
using CSharpStrings.Application.DTOs.Requests;
using CSharpStrings.Application.DTOs.Responses;
using CSharpStrings.Domain.Entities;

namespace CSharpStrings.Application.Handlers.StepTwo
{
    public class GetStepTwoRequestHandler : IRequestHandler<GetStepTwoRequestDto, GetStepTwoResponseDto>
    {
        public Task<GetStepTwoResponseDto> Handle(GetStepTwoRequestDto request, CancellationToken cancellationToken)
        {
            var response = new GetStepTwoResponseDto();
            response.Sum = 0;

            if (!string.IsNullOrWhiteSpace(request.Numbers))
            {
                var numbers = request.Numbers.Split(',', StringSplitOptions.RemoveEmptyEntries)
                    .Select(n => int.TryParse(n, out var x) ? x : 0);
                response.Sum = numbers.Sum();
            }

            return Task.FromResult(response);
        }
    }
}