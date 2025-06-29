using CSharpStrings.Application.DTOs.Responses;
using MediatR;

namespace CSharpStrings.Application.DTOs.Requests
{
    public class GetStepSixRequestDto : IRequest<GetStepSixResponseDto>
    {
        public string Numbers { get; set; } = string.Empty;
    }
}
