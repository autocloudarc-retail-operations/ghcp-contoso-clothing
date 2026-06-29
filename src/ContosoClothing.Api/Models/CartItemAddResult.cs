namespace ContosoClothing.Api.Models;

public sealed class CartItemAddResult
{
    public bool Success { get; init; }

    public Cart? Cart { get; init; }

    public string? ErrorMessage { get; init; }
}
