using AcademyPatternsAndPractices.Models;

namespace AcademyPatternsAndPractices.Services
{
    public interface ITotalsCalculator
    {
        void CalculateTotals(Cart cart);
    }
}