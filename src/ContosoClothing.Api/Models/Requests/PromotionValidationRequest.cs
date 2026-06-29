namespace ContosoClothing.Api.Models.Requests;

public sealed class PromotionValidationRequest
{
    public string Code { get; init; } = string.Empty;

    public decimal Subtotal { get; init; }
}
