using CSharpStrings.Models.DTO.Responses.CartResponses;
using MediatR;

namespace CSharpStrings.Models.DTO.Requests.CartRequests
{
    public class AddItemsToCartRequestDto : IRequest<GetCartResponseDto>
    {
        public List<string> Items { get; set; } = [];
    }
}
