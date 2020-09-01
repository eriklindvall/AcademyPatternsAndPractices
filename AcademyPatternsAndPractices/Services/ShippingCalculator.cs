using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AcademyPatternsAndPractices.Models;

namespace AcademyPatternsAndPractices.Services
{
    public class ShippingCalculator
    {
        public static void CalculateShipping(Cart cart)
        {
            //call various external services to query for weights, volume, distance etc and return results
            //dummy implementation: 5 units per line item
            cart.ShippingCost = 5 * cart.LineItems.Count;
        }
    }
}
