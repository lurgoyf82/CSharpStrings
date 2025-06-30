using CSharpStrings.Application.DTOs.Requests.StepTwoRequests;
using Swashbuckle.AspNetCore.Filters;

namespace CSharpStrings.Api.SwaggerExamples
{
    public class GetStepTwoRequestDtoExample : IExamplesProvider<GetStepTwoRequestDto>
    {
        public GetStepTwoRequestDto GetExamples()
        {
            return new GetStepTwoRequestDto
            {
                Numbers = "1,2,3,4,5"
            };
        }
    }
}