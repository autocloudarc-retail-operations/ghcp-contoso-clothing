using ContosoClothing.Api.Data;
using ContosoClothing.Api.Models;

namespace ContosoClothing.Api.Services;

public sealed class ProductService : IProductService
{
    public IReadOnlyList<Product> GetProducts() => SeedData.Products;

    public Product? GetProductById(int id) => SeedData.Products.FirstOrDefault(product => product.Id == id);
}
