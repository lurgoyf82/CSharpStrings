﻿namespace CSharpStrings.Models.DTO.Responses.CartResponses
{
    public class GetCartResponseDto
    {
        public List<string> Items { get; set; } = [];
        public decimal SalesTaxes { get; set; }
        public decimal Total { get; set; }
        public string? Error { get; set; }
    }
}
