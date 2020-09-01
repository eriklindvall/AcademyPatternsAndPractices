using System.Linq;
using AcademyPatternsAndPractices.Models;

namespace AcademyPatternsAndPractices.Services
{
    public class TotalsCalculator : ITotalsCalculator
    {

        private readonly IPromotionsCalculator _promotionsCalculator;
        private readonly IShippingCalculator _shippingCalculator;
        private readonly ITaxCalculator _taxCalculator;

        public TotalsCalculator(IPromotionsCalculator promotionsCalculator, IShippingCalculator shippingCalculator, ITaxCalculator taxCalculator)
        {
            _promotionsCalculator = promotionsCalculator;
            _shippingCalculator = shippingCalculator;
            _taxCalculator = taxCalculator;
        }

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
