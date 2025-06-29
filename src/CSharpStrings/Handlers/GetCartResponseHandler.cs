using CSharpStrings.Models.DTO.Requests.CartRequests;
using CSharpStrings.Models.DTO.Responses.CartResponses;
using CSharpStrings.Models.Entities;
using CSharpStrings.Services;
using MediatR;

namespace CSharpStrings.Handlers
{
    public class GetCartResponseHandler : IRequestHandler<AddItemsToCartRequestDto, GetCartResponseDto>
    {
        private readonly ILogger<GetCartResponseHandler> _logger;
        private readonly IMediator _mediator;
        private readonly CartOutputFormatter _outputFormatter;
        private readonly CartService _cartService;
        private readonly InputParser _inputParser;

        public GetCartResponseHandler(ILogger<GetCartResponseHandler> logger, IMediator mediator)
        {
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
            _outputFormatter = new CartOutputFormatter();
            _cartService = new CartService();
            _inputParser = new InputParser();
        }

        public async Task<GetCartResponseDto> Handle(AddItemsToCartRequestDto request, CancellationToken cancellationToken)
        {


            if (request?.Items == null || !request.Items.Any())
            {
                //throw new ArgumentException("Request cannot be null or empty.");
                return await ReturnError("La request � null o vuoda.");
            }
                
            var cart = new Cart();
            var response = new GetCartResponseDto();


            try
            {
                foreach (var itemText in request.Items)
                {
                    _inputParser.SetText(itemText);
                    var item = _inputParser.Parse();
                    _cartService.AddItem(cart, item);
                }
            }
            catch (Exception ex)
            {
                return await ReturnError(ex.Message);
            }

            response = _outputFormatter.GetCartResponse(cart);
            return await Task.FromResult(response);
        }

        private static async Task<GetCartResponseDto> ReturnError(string? message)
        {
            return await Task.FromResult(new GetCartResponseDto
            {
                Items = new List<string>(),
                SalesTaxes = 0m,
                Total = 0m,
                Error = message
            });
        }
    }
}
