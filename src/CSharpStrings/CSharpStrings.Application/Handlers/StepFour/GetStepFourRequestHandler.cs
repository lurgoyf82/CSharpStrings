using CSharpStrings.Application.DTOs.Requests;
using CSharpStrings.Application.DTOs.Responses;
using CSharpStrings.Domain.Entities;
using CSharpStrings.Infrastructure.Services;
using MediatR;

namespace CSharpStrings.Application.Handlers.StepFour
{
    public class GetStepFourRequestHandler : IRequestHandler<GetStepFourRequestDto, GetStringResponseDto>
    {
        public Task<GetStringResponseDto> Handle(GetStepFourRequestDto request, CancellationToken cancellationToken)
        {
            //STEP 3 +
            //Numbers bigger than 1000 should be ignored, for example “1000,2” should return 2

            GetStringResponseDto response = new();
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
                AllowNegatives = false,
                IgnoreAboveOrEqual = 1000
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