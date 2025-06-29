using CSharpStrings.Application.DTOs.Responses;
using MediatR;

namespace CSharpStrings.Application.DTOs.Requests
{
    public class GetStepThreeRequestDto : IRequest<GetStepThreeResponseDto>
    {
        public string Numbers { get; set; } = string.Empty;
    }
}
