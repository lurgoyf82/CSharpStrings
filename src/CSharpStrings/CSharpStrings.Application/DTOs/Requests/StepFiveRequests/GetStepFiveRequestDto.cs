using CSharpStrings.Application.DTOs.Responses;
using MediatR;

namespace CSharpStrings.Application.DTOs.Requests
{
    public class GetStepFiveRequestDto : IRequest<GetStringResponseDto>
    {
        public string Numbers { get; set; } = string.Empty;
    }
}
