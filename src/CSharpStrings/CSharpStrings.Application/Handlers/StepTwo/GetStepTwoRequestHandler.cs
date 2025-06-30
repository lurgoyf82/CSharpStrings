using CSharpStrings.Application.DTOs.Requests.StepTwoRequests;
using CSharpStrings.Application.DTOs.Responses.StepTwoResponses;
using CSharpStrings.Domain.Entities;
using CSharpStrings.Infrastructure.Services;
using MediatR;

namespace CSharpStrings.Application.Handlers.StepTwo
{
    public class GetStepTwoRequestHandler : IRequestHandler<GetStepTwoRequestDto, GetStepTwoResponseDto>
    {
        public Task<GetStepTwoResponseDto> Handle(GetStepTwoRequestDto request, CancellationToken cancellationToken)
        {
            //STEP 1 +
            //Allow the Add method to handle an unknown amount of numbers.

            GetStepTwoResponseDto response = new();
            /*
                public List<string>? Delimiters { get; set; } = null;
                public bool AllowMultipleDelimeters { get; set; } = true;
                public int MaxDelimeterSize { get; set; } = 1;
                public int MaxNumbers { get; set; } = 0;
                public bool AllowNegatives { get; set; } = true;
                public int IgnoreAboveOrEqual { get; set; } = 0;
            */

            var options = new CalculatorOptions
            {
                Delimiters = new List<string> { "," },
                AllowMultipleDelimeters = false,
                MaxDelimeterSize = 0,
                MaxNumbers = 0,
                AllowNegatives = true,
                IgnoreAboveOrEqual = 0
            };

            var calculatorService = new CalculatorService();
            try
            {
                response.Sum = calculatorService.CalculateSum(request.Numbers, options);
            }
            catch (ArgumentException ex)
            {
                response.Error = ex.Message;
            }

            return Task.FromResult(response);
        }
    }
}