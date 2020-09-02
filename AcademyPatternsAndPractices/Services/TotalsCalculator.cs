using System.Linq;
using AcademyPatternsAndPractices.Models;

namespace AcademyPatternsAndPractices.Services
{
    public class TotalsCalculator
    {
        private readonly PromotionsCalculator _promotionsCalculator = new PromotionsCalculator();
        private readonly ShippingCalculator _shippingCalculator = new ShippingCalculator();
        private readonly TaxCalculator _taxCalculator = new TaxCalculator();
        public void CalculateTotals(Cart cart)
        {
            cart.Discount = _promotionsCalculator.CalculateTotalDiscount(cart);
            cart.TotalGoodsAmount = cart.LineItems.Sum(lineItem => lineItem.Count * lineItem.UnitPrice) - cart.Discount;
            cart.ShippingCost = _shippingCalculator.CalculateShipping(cart);
            cart.Tax = _taxCalculator.CalculateTaxes(cart);
            cart.TotalAmount = cart.TotalGoodsAmount + cart.ShippingCost + cart.Tax;
        }
    }
}
