using System.Reflection;
using ContosoClothing.Api.Models;
using ContosoClothing.Api.Models.Requests;
using ContosoClothing.Api.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<IProductService, ProductService>();
builder.Services.AddSingleton<IPromotionService, PromotionService>();
builder.Services.AddSingleton<ICartService, CartService>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI();

app.MapGet("/api/products", (IProductService productService) =>
{
    // TODO: Add product search by category.
    return Results.Ok(productService.GetProducts());
})
.WithName("GetProducts")
.WithOpenApi();

app.MapGet("/api/products/{id}", (int id, IProductService productService) =>
{
    var product = productService.GetProductById(id);

    return product is null
        ? Results.NotFound(ApiError.Create($"Product '{id}' was not found."))
        : Results.Ok(product);
})
.WithName("GetProductById")
.WithOpenApi();

app.MapGet("/api/cart/{cartId}", (string cartId, ICartService cartService) =>
{
    if (string.IsNullOrWhiteSpace(cartId))
    {
        return Results.ValidationProblem(new Dictionary<string, string[]>
        {
            ["cartId"] = ["Cart id is required."]
        });
    }

    return Results.Ok(cartService.GetCart(cartId));
})
.WithName("GetCart")
.WithOpenApi();

app.MapPost("/api/cart/{cartId}/items", (string cartId, AddCartItemRequest request, ICartService cartService) =>
{
    if (string.IsNullOrWhiteSpace(cartId))
    {
        return Results.ValidationProblem(new Dictionary<string, string[]>
        {
            ["cartId"] = ["Cart id is required."]
        });
    }

    if (request.Quantity < 1)
    {
        // TODO: Add better validation messages.
        return Results.ValidationProblem(new Dictionary<string, string[]>
        {
            ["quantity"] = ["Quantity must be at least 1."]
        });
    }

    var addResult = cartService.TryAddItem(cartId, request.ProductId, request.Quantity);

    return addResult.Success
        ? Results.Ok(addResult.Cart)
        : Results.NotFound(ApiError.Create(addResult.ErrorMessage!));
})
.WithName("AddCartItem")
.WithOpenApi();

app.MapPost("/api/promotions/validate", (PromotionValidationRequest request, IPromotionService promotionService) =>
{
    if (string.IsNullOrWhiteSpace(request.Code))
    {
        return Results.ValidationProblem(new Dictionary<string, string[]>
        {
            ["code"] = ["Promo code is required."]
        });
    }

    if (request.Subtotal < 0)
    {
        return Results.ValidationProblem(new Dictionary<string, string[]>
        {
            ["subtotal"] = ["Subtotal must be zero or greater."]
        });
    }

    return Results.Ok(promotionService.ValidatePromotion(request.Code, request.Subtotal));
})
.WithName("ValidatePromotion")
.WithOpenApi();

app.MapGet("/health", () => Results.Ok(new HealthResponse("Healthy")))
    .WithName("Health")
    .WithOpenApi();

app.MapGet("/api/version", (IHostEnvironment environment) =>
{
    var version = Assembly.GetExecutingAssembly().GetName().Version?.ToString() ?? "1.0.0";
    return Results.Ok(new VersionResponse("GHCP Contoso Clothing", version, environment.EnvironmentName));
})
.WithName("GetVersion")
.WithOpenApi();

// TODO: Add structured logging, correlation id support, and authentication as future extensions.
app.Run();

public partial class Program;
