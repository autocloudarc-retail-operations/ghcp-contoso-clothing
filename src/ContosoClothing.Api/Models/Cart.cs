namespace ContosoClothing.Api.Models;

public sealed class Cart
{
    public string CartId { get; init; } = string.Empty;

    public List<CartItem> Items { get; init; } = [];

    public decimal Subtotal { get; init; }
}
