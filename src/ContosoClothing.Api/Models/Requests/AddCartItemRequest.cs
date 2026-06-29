namespace ContosoClothing.Api.Models.Requests;

public sealed class AddCartItemRequest
{
    public int ProductId { get; init; }

    public int Quantity { get; init; }
}
