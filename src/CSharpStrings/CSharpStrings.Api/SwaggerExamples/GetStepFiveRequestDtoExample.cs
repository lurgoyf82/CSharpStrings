using CSharpStrings.Application.DTOs.Requests.StepFiveRequests;
using Swashbuckle.AspNetCore.Filters;

namespace CSharpStrings.Api.SwaggerExamples
{
    public class GetStepFiveRequestDtoExample : IExamplesProvider<GetStepFiveRequestDto>
    {
        public GetStepFiveRequestDto GetExamples()
        {
            return new GetStepFiveRequestDto
            {
                Numbers = "//[***]//1***2***3"
            };
        }
    }
}