using AcademyPatternsAndPractices.Models;

namespace AcademyPatternsAndPractices.Services
{
    public interface IPromotionsCalculator
    {
        decimal CalculateTotalDiscount(Cart cart);
    }
}