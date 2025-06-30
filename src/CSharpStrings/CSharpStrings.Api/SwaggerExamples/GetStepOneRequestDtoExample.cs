using CSharpStrings.Application.DTOs.Requests.StepOneRequests;
using Swashbuckle.AspNetCore.Filters;

namespace CSharpStrings.Api.SwaggerExamples
{
    public class GetStepOneRequestDtoExample : IExamplesProvider<GetStepOneRequestDto>
    {
        public GetStepOneRequestDto GetExamples()
        {
            return new GetStepOneRequestDto
            {
                Numbers = "0,1,2"
            };
        }
    }
}