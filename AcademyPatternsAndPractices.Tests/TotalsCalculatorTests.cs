using System.Collections.Generic;
using AcademyPatternsAndPractices.Models;
using AcademyPatternsAndPractices.Services;
using FakeItEasy;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AcademyPatternsAndPractices.Tests
{
    [TestClass]
    public class TotalsCalculatorTests
    {
        [TestMethod]
        public void Should_sum_line_items_correctly()
        {
            //Arrange
            Cart cart = new Cart()
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
                    new LineItem() { SkuId = 1, Name = "T-shirt", Count = 1, UnitPrice = 150 },
                    new LineItem() { SkuId = 1, Name = "Strumpor", Count = 3, UnitPrice = 5 }
                }
            };
            var taxCalculator = A.Fake<ITaxCalculator>();
            var shippingCalculator = A.Fake<IShippingCalculator>();
            var promotionCalculator = A.Fake<IPromotionsCalculator>();
            
            var totalsCalculator = new TotalsCalculator(promotionCalculator, shippingCalculator, taxCalculator);

            //Act
            totalsCalculator.CalculateTotals(cart);

            //Assert
            Assert.AreEqual(cart.TotalAmount, 165);
        }
    }
}