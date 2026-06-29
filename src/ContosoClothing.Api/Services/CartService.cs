using ContosoClothing.Api.Models;

namespace ContosoClothing.Api.Services;

public sealed class CartService(IProductService productService) : ICartService
{
    private readonly Dictionary<string, List<CartItem>> carts = new(StringComparer.OrdinalIgnoreCase);

    public Cart GetCart(string cartId)
    {
        var items = carts.TryGetValue(cartId, out var existingItems)
            ? existingItems
            : [];

        return BuildCart(cartId, items);
    }

    public CartItemAddResult TryAddItem(string cartId, int productId, int quantity)
    {
        var product = productService.GetProductById(productId);

        if (product is null)
        {
            return new CartItemAddResult
            {
                Success = false,
                ErrorMessage = $"Product '{productId}' was not found."
            };
        }

        if (!carts.TryGetValue(cartId, out var items))
        {
            items = [];
            carts[cartId] = items;
        }

        items.Add(new CartItem
        {
            ProductId = product.Id,
            ProductName = product.Name,
            Quantity = quantity,
            UnitPrice = product.Price
        });

        // TODO: Refactor repeated cart calculation logic if cart rules grow.
        return new CartItemAddResult
        {
            Success = true,
            Cart = BuildCart(cartId, items)
        };
    }

    private static Cart BuildCart(string cartId, List<CartItem> items) => new()
    {
        CartId = cartId,
        Items = items.Select(item => new CartItem
        {
            ProductId = item.ProductId,
            ProductName = item.ProductName,
            Quantity = item.Quantity,
            UnitPrice = item.UnitPrice
        }).ToList(),
        Subtotal = items.Sum(item => item.LineTotal)
    };
}
