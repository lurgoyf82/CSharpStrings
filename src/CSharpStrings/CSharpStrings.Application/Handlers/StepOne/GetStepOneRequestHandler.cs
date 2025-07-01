using CSharpStrings.Application.DTOs.Requests;
using CSharpStrings.Application.DTOs.Responses;
using CSharpStrings.Domain.Entities;
using CSharpStrings.Infrastructure.Services;
using MediatR;

namespace CSharpStrings.Application.Handlers.StepOne
{
    public class GetStepOneRequestHandler : IRequestHandler<GetStepOneRequestDto, GetStringResponseDto>
    {
        public Task<GetStringResponseDto> Handle(GetStepOneRequestDto request, CancellationToken cancellationToken)
        {
            //Create a simple String calculator with a method int Add(string numbers).

            //The method can take 0, 1 or 2 numbers, separated by commas, and will return their sum, examples:

            //“” should return 0
            //“1” should return 1
            //“1,2” should return 3

            //Start with the simplest test case of an empty string and move to one and two numbers.
            //Remember to solve things as simply as possible so that you force yourself to write tests you did not think about.
            //Remember to refactor after each passing test.

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
                MaxNumbers = 3,
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
                response.Error= ex.Message;
            }

            return Task.FromResult(response);
        }
    }
}