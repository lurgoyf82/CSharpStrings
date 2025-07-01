using CSharpStrings.Application.DTOs.Responses;
using MediatR;

namespace CSharpStrings.Application.DTOs.Requests
{
    public class GetStepSixRequestDto : IRequest<GetStringResponseDto>
    {
        public string Numbers { get; set; } = string.Empty;
    }
}
