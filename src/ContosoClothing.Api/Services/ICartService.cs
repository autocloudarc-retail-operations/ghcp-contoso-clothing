using ContosoClothing.Api.Models;

namespace ContosoClothing.Api.Services;

public interface ICartService
{
    Cart GetCart(string cartId);

    CartItemAddResult TryAddItem(string cartId, int productId, int quantity);
}
