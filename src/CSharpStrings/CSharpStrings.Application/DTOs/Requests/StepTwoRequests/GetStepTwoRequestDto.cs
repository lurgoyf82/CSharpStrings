using CSharpStrings.Application.DTOs.Responses.StepTwoResponses;
using MediatR;

namespace CSharpStrings.Application.DTOs.Requests.StepTwoRequests
{
    public class GetStepTwoRequestDto : IRequest<GetStepTwoResponseDto>
    {
        public string Numbers { get; set; } = string.Empty;
    }
}
