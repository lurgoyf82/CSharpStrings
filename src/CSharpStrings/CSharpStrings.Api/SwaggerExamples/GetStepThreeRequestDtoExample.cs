using CSharpStrings.Application.DTOs.Requests.StepThreeRequests;
using Swashbuckle.AspNetCore.Filters;

namespace CSharpStrings.Api.SwaggerExamples
{
    public class GetStepThreeRequestDtoExample : IExamplesProvider<GetStepThreeRequestDto>
    {
        public GetStepThreeRequestDto GetExamples()
        {
            return new GetStepThreeRequestDto
            {
                Numbers = "1,2,-3,4,-5"
            };
        }
    }
}