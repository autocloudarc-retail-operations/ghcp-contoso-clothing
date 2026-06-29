using ContosoClothing.Api.Models;

namespace ContosoClothing.Api.Data;

public static class SeedData
{
    public static readonly IReadOnlyList<Product> Products =
    [
        new() { Id = 1, Name = "Trail Jacket", Category = "Outerwear", Price = 89.99m, QuantityAvailable = 12 },
        new() { Id = 2, Name = "Canvas Tote", Category = "Accessories", Price = 24.99m, QuantityAvailable = 30 },
        new() { Id = 3, Name = "Running Socks", Category = "Footwear", Price = 12.50m, QuantityAvailable = 48 },
        new() { Id = 4, Name = "Travel Backpack", Category = "Accessories", Price = 74.00m, QuantityAvailable = 16 },
        new() { Id = 5, Name = "Everyday Hoodie", Category = "Tops", Price = 54.99m, QuantityAvailable = 20 },
        new() { Id = 6, Name = "Denim Shirt", Category = "Tops", Price = 44.99m, QuantityAvailable = 18 },
        new() { Id = 7, Name = "Water Bottle", Category = "Accessories", Price = 18.00m, QuantityAvailable = 40 },
        new() { Id = 8, Name = "Knit Beanie", Category = "Accessories", Price = 19.99m, QuantityAvailable = 25 }
    ];

    public static readonly IReadOnlyList<PromoCode> PromoCodes =
    [
        new() { Code = "SAVE10", DiscountPercent = 10, MinimumSubtotal = 50m, IsActive = true },
        new() { Code = "FREESHIP", DiscountPercent = 0, MinimumSubtotal = 25m, IsActive = true },
        new() { Code = "VIP20", DiscountPercent = 20, MinimumSubtotal = 100m, IsActive = true }
    ];
}
