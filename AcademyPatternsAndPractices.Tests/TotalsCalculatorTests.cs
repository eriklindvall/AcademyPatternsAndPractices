using System.Collections.Generic;
using AcademyPatternsAndPractices.Models;
using AcademyPatternsAndPractices.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace AcademyPatternsAndPractices.Tests
{
    [TestClass]
    public class TotalsCalculatorTests
    {
        [TestMethod]
        public void Test1()
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
                    new LineItem() { SkuId = 1, Name = "T-shirt", Count = 1, UnitPrice = 159 },
                    new LineItem() { SkuId = 1, Name = "Strumpor", Count = 3, UnitPrice = 49 }
                }
            }; 
            var totalsCalculator = new TotalsCalculator();

            //Act
            totalsCalculator.CalculateTotals(cart);

            //Assert
            Assert.AreEqual(cart.TotalAmount, 208);
        }
    }
}