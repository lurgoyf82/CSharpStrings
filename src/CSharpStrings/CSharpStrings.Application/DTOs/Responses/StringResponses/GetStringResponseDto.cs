namespace CSharpStrings.Application.DTOs.Responses
{
    public class GetStringResponseDto
    {
        public int Sum { get; set; }
        public string? Error { get; set; } = string.Empty;
    }
}
