using CSharpStrings.Application.DTOs.Responses;
using MediatR;

namespace CSharpStrings.Application.DTOs.Requests
{
    public class GetStepTwoRequestDto : IRequest<GetStepTwoResponseDto>
    {
        public string Numbers { get; set; } = string.Empty;
    }
}
