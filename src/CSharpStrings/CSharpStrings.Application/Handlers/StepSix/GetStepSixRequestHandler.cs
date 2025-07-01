using CSharpStrings.Application.DTOs.Requests;
using CSharpStrings.Application.DTOs.Responses;
using CSharpStrings.Domain.Entities;
using CSharpStrings.Infrastructure.Services;
using MediatR;
using System.Text.RegularExpressions;

namespace CSharpStrings.Application.Handlers.StepSix
{
    public class GetStepSixRequestHandler : IRequestHandler<GetStepSixRequestDto, GetStringResponseDto>
    {
        public Task<GetStringResponseDto> Handle(GetStepSixRequestDto request, CancellationToken cancellationToken)
        {
            //STEP 5 +
            //Allow multiple delimiters like this:
            //    //[delim1][delim2]//
            //    for example
            //    //[*][%]//1*2%3
            //    should return 6

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
                Delimiters = null,
                AllowMultipleDelimeters = true,
                MaxDelimeterSize = 1,
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