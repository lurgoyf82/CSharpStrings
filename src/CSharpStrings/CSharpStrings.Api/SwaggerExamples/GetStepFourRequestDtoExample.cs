using CSharpStrings.Application.DTOs.Requests;
using Swashbuckle.AspNetCore.Filters;

namespace CSharpStrings.Api.SwaggerExamples
{
    public class GetStepFourRequestDtoExample : IExamplesProvider<GetStepFourRequestDto>
    {
        public GetStepFourRequestDto GetExamples()
        {
            return new GetStepFourRequestDto
            {
                Numbers = "1000,2,1001"
            };
        }
    }
}