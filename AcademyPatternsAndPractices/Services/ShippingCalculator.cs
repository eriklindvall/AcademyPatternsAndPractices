using AcademyPatternsAndPractices.Models;

namespace AcademyPatternsAndPractices.Services
{
    public class ShippingCalculator : IShippingCalculator
    {
        public decimal CalculateShipping(Cart cart)
        {
            //call various external services to query for weights, volume, distance etc and return results
            //dummy implementation: 5 units per line item
            return 5 * cart.LineItems.Count;
        }
    }
}
