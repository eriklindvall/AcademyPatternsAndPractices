using AcademyPatternsAndPractices.Models;

namespace AcademyPatternsAndPractices.Services
{
    public interface IShippingCalculator
    {
        decimal CalculateShipping(Cart cart);
    }
}