using CSharpStrings.Application.DTOs.Requests;
using CSharpStrings.Application.DTOs.Responses;
using MediatR;
using Microsoft.VisualBasic;
using System;
using System.ComponentModel;
using System.Diagnostics.Metrics;
using System.Reflection;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CSharpStrings.Application.Handlers.StepOne
{
    public class GetStepOneRequestHandler : IRequestHandler<GetStepOneRequestDto, GetStepOneResponseDto>
    {
        public Task<GetStepOneResponseDto> Handle(GetStepOneRequestDto request, CancellationToken cancellationToken)
        {
            //## Step 1 
            //    Create a simple String calculator with a method int Add(string numbers).

            //    1.The method can take 0, 1 or 2 numbers, separated by commas, and will return their sum, examples:
            //        “”    should return 0
            //        “1”   should return 1
            //        “1,2” should return 3
            //    2.Start with the simplest test case of an empty string and move to one and two numbers.
            //    3.Remember to solve things as simply as possible so that you force yourself to write tests you did not think about.
            //    4.Remember to refactor after each passing test.

            var response = new GetStepOneResponseDto();
            response.Sum = 0;

            if (string.IsNullOrWhiteSpace(request.Numbers))
            {
                return Task.FromResult(response);
            }

            //if request.Numbers contains a comma, split it into an array of strings
            if (!request.Numbers.Contains(','))
            {
                //no virgola
                try
                {
                    //int ok
                    response.Sum = int.Parse(request.Numbers);
                }
                catch (FormatException)
                {
                    //errore
                    response.Error = $"Invalid number: {request.Numbers}";
                }
            }
            else
            {
                string[] numberList = request.Numbers.Split(',');

                var number = 0;
                foreach (string? numberString in numberList)
                {
                    try
                    {
                        //int ok
                        number += int.Parse(request.Numbers);
                    }
                    catch (FormatException)
                    {
                        //errore
                        response.Error = $"Invalid number: {request.Numbers}";
                        return Task.FromResult(response);
                    }
                }

                response.Sum = number;
            }

            return Task.FromResult(response);
        }
    }
}