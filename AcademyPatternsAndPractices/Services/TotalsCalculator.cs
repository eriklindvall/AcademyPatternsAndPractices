using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcademyPatternsAndPractices.Models;

namespace AcademyPatternsAndPractices.Services
{
    public class TotalsCalculator
    {
        public static void CalculateTotals(Cart cart)
        {
            PromotionsCalculator.CalculateTotalDiscount(cart);
            cart.TotalGoodsAmount = cart.LineItems.Sum(lineItem => lineItem.Count * lineItem.UnitPrice) - cart.Discount;
            ShippingCalculator.CalculateShipping(cart);
            TaxCalculator.CalculateTaxes(cart);
            cart.TotalAmount = cart.TotalGoodsAmount + cart.Tax;
        }
    }
}
