using CSharpStrings.Application.DTOs.Requests;
using CSharpStrings.Application.DTOs.Responses;
using CSharpStrings.Domain.Entities;
using CSharpStrings.Infrastructure.Services;
using MediatR;
using System.Text.RegularExpressions;

namespace CSharpStrings.Application.Handlers.StepFive
{
    public class GetStepFiveRequestHandler : IRequestHandler<GetStepFiveRequestDto, GetStringResponseDto>
    {
        public Task<GetStringResponseDto> Handle(GetStepFiveRequestDto request, CancellationToken cancellationToken)
        {
            //STEP 4 +
            //Support different delimiters Delimiters can be of any length with the following format:
            //     //[delimiter]//
            //     for example:
            //     //[***]//1***2***3
            //     should return 6

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