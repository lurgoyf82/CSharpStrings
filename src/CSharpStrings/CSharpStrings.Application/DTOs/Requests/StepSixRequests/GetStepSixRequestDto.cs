using CSharpStrings.Application.DTOs.Responses.StepSixResponses;
using MediatR;

namespace CSharpStrings.Application.DTOs.Requests.StepSixRequests
{
    public class GetStepSixRequestDto : IRequest<GetStepSixResponseDto>
    {
        public string Numbers { get; set; } = string.Empty;
    }
}
