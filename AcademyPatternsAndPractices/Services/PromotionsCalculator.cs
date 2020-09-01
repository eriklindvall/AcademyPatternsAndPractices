using System.Linq;
using AcademyPatternsAndPractices.Models;

namespace AcademyPatternsAndPractices.Services
{
    public class PromotionsCalculator : IPromotionsCalculator
    {
        public decimal CalculateTotalDiscount(Cart cart)
        {
            //call various external services to calculate what promotions to apply, check coupons etc
            //dummy implementation: apply "3 for 2" exactly once if applicable
            return cart.LineItems.FirstOrDefault(lineItem => lineItem.Count >= 3)?.UnitPrice ?? 0;
        }
    }
}
