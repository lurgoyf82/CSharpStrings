using CSharpStrings.Application.DTOs.Responses.StepFiveResponses;
using MediatR;

namespace CSharpStrings.Application.DTOs.Requests.StepFiveRequests
{
    public class GetStepFiveRequestDto : IRequest<GetStepFiveResponseDto>
    {
        public string Numbers { get; set; } = string.Empty;
    }
}
