using CSharpStrings.Application.DTOs.Responses;
using MediatR;

namespace CSharpStrings.Application.DTOs.Requests
{
    public class GetStepSevenRequestDto : IRequest<GetStepSevenResponseDto>
    {
        public string Numbers { get; set; } = string.Empty;
    }
}
