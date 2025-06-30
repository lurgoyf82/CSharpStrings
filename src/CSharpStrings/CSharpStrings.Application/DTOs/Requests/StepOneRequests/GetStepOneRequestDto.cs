using CSharpStrings.Application.DTOs.Responses.StepOneResponses;
using MediatR;

namespace CSharpStrings.Application.DTOs.Requests.StepOneRequests
{
    public class GetStepOneRequestDto : IRequest<GetStepOneResponseDto>
    {
        public string Numbers { get; set; } = string.Empty;
    }
}

