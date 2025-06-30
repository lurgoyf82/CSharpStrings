using CSharpStrings.Application.DTOs.Responses.StepSevenResponses;
using MediatR;

namespace CSharpStrings.Application.DTOs.Requests.StepSevenRequests
{
    public class GetStepSevenRequestDto : IRequest<GetStepSevenResponseDto>
    {
        public string Numbers { get; set; } = string.Empty;
    }
}
