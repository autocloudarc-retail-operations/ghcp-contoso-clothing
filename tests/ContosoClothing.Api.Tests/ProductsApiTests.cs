using System.Net;
using System.Net.Http.Json;
using ContosoClothing.Api.Models;
using ContosoClothing.Api.Models.Requests;
using Microsoft.AspNetCore.Mvc.Testing;

namespace ContosoClothing.Api.Tests;

public sealed class ProductsApiTests : IClassFixture<WebApplicationFactory<Program>>
{
    private readonly HttpClient client;

    public ProductsApiTests(WebApplicationFactory<Program> factory)
    {
        client = factory.CreateClient();
    }

    [Fact]
    public async Task ProductListReturnsProducts()
    {
        var products = await client.GetFromJsonAsync<List<Product>>("/api/products");

        Assert.NotNull(products);
        Assert.NotEmpty(products);
        Assert.Contains(products, product => product.Name == "Trail Jacket");
    }

    [Fact]
    public async Task UnknownProductReturnsNotFound()
    {
        var response = await client.GetAsync("/api/products/999");

        Assert.Equal(HttpStatusCode.NotFound, response.StatusCode);
    }

    [Fact]
    public async Task CartRejectsQuantityLessThanOne()
    {
        var response = await client.PostAsJsonAsync("/api/cart/demo-cart/items", new AddCartItemRequest
        {
            ProductId = 1,
            Quantity = 0
        });

        Assert.Equal(HttpStatusCode.BadRequest, response.StatusCode);
    }

    [Fact]
    public async Task CartAcceptsValidItem()
    {
        var addResponse = await client.PostAsJsonAsync("/api/cart/demo-cart/items", new AddCartItemRequest
        {
            ProductId = 1,
            Quantity = 2
        });

        var cart = await client.GetFromJsonAsync<Cart>("/api/cart/demo-cart");

        Assert.Equal(HttpStatusCode.OK, addResponse.StatusCode);
        Assert.NotNull(cart);
        Assert.Equal(179.98m, cart.Subtotal);
        Assert.Single(cart.Items);
    }

    [Fact]
    public async Task PromoCodeAppliesWhenValid()
    {
        var response = await client.PostAsJsonAsync("/api/promotions/validate", new PromotionValidationRequest
        {
            Code = "SAVE10",
            Subtotal = 75m
        });

        var result = await response.Content.ReadFromJsonAsync<PromotionValidationResult>();

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.NotNull(result);
        Assert.True(result.IsValid);
        Assert.Equal(10, result.DiscountPercent);
    }

    [Fact]
    public async Task PromoCodeIsRejectedWhenSubtotalIsTooLow()
    {
        var response = await client.PostAsJsonAsync("/api/promotions/validate", new PromotionValidationRequest
        {
            Code = "VIP20",
            Subtotal = 20m
        });

        var result = await response.Content.ReadFromJsonAsync<PromotionValidationResult>();

        Assert.Equal(HttpStatusCode.OK, response.StatusCode);
        Assert.NotNull(result);
        Assert.False(result.IsValid);
    }

    [Fact]
    public async Task HealthEndpointReturnsHealthyResponse()
    {
        var health = await client.GetFromJsonAsync<HealthResponse>("/health");

        Assert.NotNull(health);
        Assert.Equal("Healthy", health.Status);
    }
}
