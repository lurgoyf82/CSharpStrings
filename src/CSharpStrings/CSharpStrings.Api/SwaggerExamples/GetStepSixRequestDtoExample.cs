using CSharpStrings.Application.DTOs.Requests;
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