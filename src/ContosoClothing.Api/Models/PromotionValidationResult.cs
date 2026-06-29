namespace ContosoClothing.Api.Models;

public sealed class PromotionValidationResult
{
    public string Code { get; init; } = string.Empty;

    public bool IsValid { get; init; }

    public int DiscountPercent { get; init; }

    public decimal MinimumSubtotal { get; init; }

    public string Message { get; init; } = string.Empty;
}
