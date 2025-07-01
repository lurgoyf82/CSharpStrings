using CSharpStrings.Application.DTOs.Requests;
using CSharpStrings.Application.DTOs.Responses;
using CSharpStrings.Domain.Entities;
using CSharpStrings.Infrastructure.Services;
using MediatR;

namespace CSharpStrings.Application.Handlers.StepThree
{
    public class GetStepThreeRequestHandler : IRequestHandler<GetStepThreeRequestDto, GetStringResponseDto>
    {
        public Task<GetStringResponseDto> Handle(GetStepThreeRequestDto request, CancellationToken cancellationToken)
        {
            //STEP 2 +
            //Calling Add with a negative number will throw an exception “negatives not allowed” - and the negative that was passed.
            //If there are multiple negatives, show all of them in the exception message

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