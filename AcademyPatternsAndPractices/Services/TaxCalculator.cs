using AcademyPatternsAndPractices.Models;

namespace AcademyPatternsAndPractices.Services
{
    public class TaxCalculator
    {
        public static void CalculateTaxes(Cart cart)
        {
            //call various services to check for tax rates in different countries, states
            //dummy implementation: 25% on goods, 12% on shipping
            cart.Tax = 0.25m * cart.TotalGoodsAmount + 0.12m * cart.ShippingCost;
        }
    }
}
