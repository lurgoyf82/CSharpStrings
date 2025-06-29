using CSharpStrings.Application.DTOs.Responses;
using MediatR;

namespace CSharpStrings.Application.DTOs.Requests
{
    public class GetStepFourRequestDto : IRequest<GetStepFourResponseDto>
    {
        public string Numbers { get; set; } = string.Empty;
    }
}
