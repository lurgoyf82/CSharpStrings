using CSharpStrings.Models.DTO.Requests.CartRequests;
using Swashbuckle.AspNetCore.Filters;
using System.Net.Sockets;

public class AddItemsToCartRequestDtoExample : IExamplesProvider<AddItemsToCartRequestDto>
{
    public AddItemsToCartRequestDto GetExamples()
    {
        return new AddItemsToCartRequestDto
        {
            Items = new List<string>
            {
                "2 book at 12.49",
                "1 music CD at 14.99",
                "1 chocolate bar at 0.85",

                "1 imported box of chocolates at 10.00",
                "1 imported bottle of perfume at 47.50",

                "1 imported bottle of perfume at 27.99",
                "1 bottle of perfume at 18.99",
                "1 packet of headache pills at 9.75",
                "3 box of imported chocolates at 11.25"
            }
        };
    }
}