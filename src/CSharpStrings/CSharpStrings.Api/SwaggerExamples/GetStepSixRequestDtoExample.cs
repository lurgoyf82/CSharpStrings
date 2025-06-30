using CSharpStrings.Application.DTOs.Requests.StepSixRequests;
using Swashbuckle.AspNetCore.Filters;

namespace CSharpStrings.Api.SwaggerExamples
{
    public class GetStepSixRequestDtoExample : IExamplesProvider<GetStepSixRequestDto>
    {
        public GetStepSixRequestDto GetExamples()
        {
            return new GetStepSixRequestDto
            {
                Numbers = "//[*][%]//1*2%3"
            };
        }
    }
}