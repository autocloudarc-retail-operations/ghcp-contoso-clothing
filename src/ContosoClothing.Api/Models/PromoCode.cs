namespace ContosoClothing.Api.Models;

public sealed class PromoCode
{
    public string Code { get; init; } = string.Empty;

    public int DiscountPercent { get; init; }

    public decimal MinimumSubtotal { get; init; }

    public bool IsActive { get; init; }
}
