using ContosoClothing.Api.Models;

namespace ContosoClothing.Api.Services;

public interface IPromotionService
{
    PromotionValidationResult ValidatePromotion(string code, decimal subtotal);
}
