using CSharpStrings.Application.DTOs.Responses.StepFourResponses;
using MediatR;

namespace CSharpStrings.Application.DTOs.Requests.StepFourRequests
{
    public class GetStepFourRequestDto : IRequest<GetStepFourResponseDto>
    {
        public string Numbers { get; set; } = string.Empty;
    }
}
