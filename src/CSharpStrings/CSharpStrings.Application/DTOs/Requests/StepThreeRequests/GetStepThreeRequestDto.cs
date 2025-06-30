using CSharpStrings.Application.DTOs.Responses.StepThreeResponses;
using MediatR;

namespace CSharpStrings.Application.DTOs.Requests.StepThreeRequests
{
    public class GetStepThreeRequestDto : IRequest<GetStepThreeResponseDto>
    {
        public string Numbers { get; set; } = string.Empty;
    }
}
