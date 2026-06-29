using ContosoClothing.Api.Models;

namespace ContosoClothing.Api.Services;

public interface IProductService
{
    IReadOnlyList<Product> GetProducts();

    Product? GetProductById(int id);
}
