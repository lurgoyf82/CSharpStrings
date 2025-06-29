using CSharpStrings.Application.DTOs.Responses;
using MediatR;

namespace CSharpStrings.Application.DTOs.Requests
{
    public class GetStepFiveRequestDto : IRequest<GetStepFiveResponseDto>
    {
        public string Numbers { get; set; } = string.Empty;
    }
}
