using ContosoClothing.Api.Data;
using ContosoClothing.Api.Models;

namespace ContosoClothing.Api.Services;

public sealed class PromotionService : IPromotionService
{
    public PromotionValidationResult ValidatePromotion(string code, decimal subtotal)
    {
        var promoCode = SeedData.PromoCodes.FirstOrDefault(promo =>
            string.Equals(promo.Code, code, StringComparison.OrdinalIgnoreCase));

        if (promoCode is null)
        {
            return new PromotionValidationResult
            {
                Code = code,
                IsValid = false,
                Message = "Promo code was not found."
            };
        }

        if (!promoCode.IsActive)
        {
            // TODO: Add a unit test for inactive promo codes.
            return new PromotionValidationResult
            {
                Code = promoCode.Code,
                IsValid = false,
                DiscountPercent = promoCode.DiscountPercent,
                MinimumSubtotal = promoCode.MinimumSubtotal,
                Message = "Promo code is not active."
            };
        }

        if (subtotal < promoCode.MinimumSubtotal)
        {
            return new PromotionValidationResult
            {
                Code = promoCode.Code,
                IsValid = false,
                DiscountPercent = promoCode.DiscountPercent,
                MinimumSubtotal = promoCode.MinimumSubtotal,
                Message = $"Promo code requires a subtotal of at least {promoCode.MinimumSubtotal:0.00}."
            };
        }

        return new PromotionValidationResult
        {
            Code = promoCode.Code,
            IsValid = true,
            DiscountPercent = promoCode.DiscountPercent,
            MinimumSubtotal = promoCode.MinimumSubtotal,
            Message = "Promo code is valid."
        };
    }
}
