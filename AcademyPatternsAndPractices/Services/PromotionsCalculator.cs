using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcademyPatternsAndPractices.Models;

namespace AcademyPatternsAndPractices.Services
{
    public class PromotionsCalculator
    {
        public static void CalculateTotalDiscount(Cart cart)
        {
            //call various external services to calculate what promotions to apply, check coupons etc
            //dummy implementation: apply "3 for 2" exactly once if applicable
            cart.Discount = cart.LineItems.FirstOrDefault(lineItem => lineItem.Count >= 3)?.UnitPrice ?? 0;
        }
    }
}
