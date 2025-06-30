using CSharpStrings.Application.DTOs.Requests.StepSevenRequests;
using Swashbuckle.AspNetCore.Filters;

namespace CSharpStrings.Api.SwaggerExamples
{
    public class GetStepSevenRequestDtoExample : IExamplesProvider<GetStepSevenRequestDto>
    {
        public GetStepSevenRequestDto GetExamples()
        {
            return new GetStepSevenRequestDto
            {
                Numbers = "//[***][%%]//1***2%%3***4"
            };
        }
    }
}