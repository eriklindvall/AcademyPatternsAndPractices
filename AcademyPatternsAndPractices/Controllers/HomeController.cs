using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using AcademyPatternsAndPractices.Models;
using AcademyPatternsAndPractices.Services;

namespace AcademyPatternsAndPractices.Controllers
{
    public class HomeController : Controller
    {
        //dummy cart
        private readonly Cart _cart = new Cart()
        {
            Address = new Address()
            {
                Name = "Test Testsson",
                AddressLine1 = "Testgatan 1",
                AddressLine2 = "",
                ZipCode = 12345,
                Country = "SE"
            },

            LineItems = new List<LineItem>()
            {
                new LineItem() { SkuId = 1, Name = "T-shirt", Count = 1, UnitPrice = 159 },
                new LineItem() { SkuId = 1, Name = "Strumpor", Count = 3, UnitPrice = 49 }
            }
        };
        public HomeController()
        {
            
        }

        public IActionResult Index()
        {
            var totalsCalculator = new TotalsCalculator();
            totalsCalculator.CalculateTotals(_cart);
            return Json(_cart);
        }
    }
}
