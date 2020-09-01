using AcademyPatternsAndPractices.Models;

namespace AcademyPatternsAndPractices.Services
{
    public interface ITaxCalculator
    {
        decimal CalculateTaxes(Cart cart);
    }
}