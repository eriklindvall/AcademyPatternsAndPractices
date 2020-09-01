using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
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
            TotalsCalculator.CalculateTotals(_cart);
            return Json(_cart);
        }
    }
}
