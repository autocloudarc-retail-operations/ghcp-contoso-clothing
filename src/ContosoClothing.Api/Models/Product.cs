namespace ContosoClothing.Api.Models;

public sealed class Product
{
    public int Id { get; init; }

    public string Name { get; init; } = string.Empty;

    public string Category { get; init; } = string.Empty;

    public decimal Price { get; init; }

    public int QuantityAvailable { get; init; }
}
