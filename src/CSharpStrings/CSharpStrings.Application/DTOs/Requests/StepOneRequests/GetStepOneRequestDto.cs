using CSharpStrings.Application.DTOs.Responses;
using MediatR;

namespace CSharpStrings.Application.DTOs.Requests
{
    public class GetStepOneRequestDto : IRequest<GetStepOneResponseDto>
    {
        public string Numbers { get; set; } = string.Empty;
    }
}

