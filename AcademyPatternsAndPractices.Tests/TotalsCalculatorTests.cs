

using System.Collections.Generic;
using AcademyPatternsAndPractices.Models;
using AcademyPatternsAndPractices.Services;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using FakeItEasy;
using NUnit.Framework;

namespace AcademyPatternsAndPractices.Tests
{
    [TestFixture]
    public class TotalsCalculatorTests
    {
        [Test]
        public void Should_calculate_totals_correctly()
        {
            //Arrange
            var cart = new Cart()
            {
                Address = new Address(),
                LineItems = new List<LineItem>()
                {
                    new LineItem() {SkuId = 1, Count = 2, UnitPrice = 10},
                    new LineItem() {SkuId = 1, Count = 2, UnitPrice = 20}
                }
            };

            var promotionsCalculator = A.Fake<IPromotionsCalculator>();
            var shippingCalculator = A.Fake<IShippingCalculator>();
            var taxCalculator = A.Fake<ITaxCalculator>();
            var totalsCalculator = new TotalsCalculator(promotionsCalculator, shippingCalculator, taxCalculator);

            //Act
            totalsCalculator.CalculateTotals(cart);

            //Assert
            Assert.AreEqual(60m, cart.TotalGoodsAmount);
            Assert.AreEqual(60m, cart.TotalAmount);

        }

        [Test]
        public void Should_account_for_discount()
        {
            //Arrange
            var cart = new Cart()
            {
                Address = new Address(),
                LineItems = new List<LineItem>()
                {
                    new LineItem() {SkuId = 1, Count = 1, UnitPrice = 100}
                }
            };

            var promotionsCalculator = A.Fake<IPromotionsCalculator>();
            A.CallTo(() => promotionsCalculator.CalculateTotalDiscount(null)).WithAnyArguments().Returns(10);

            var shippingCalculator = A.Fake<IShippingCalculator>();
            var taxCalculator = A.Fake<ITaxCalculator>();
            var totalsCalculator = new TotalsCalculator(promotionsCalculator, shippingCalculator, taxCalculator);

            //Act
            totalsCalculator.CalculateTotals(cart);

            //Assert
            Assert.AreEqual(10m, cart.Discount);
            Assert.AreEqual(90m, cart.TotalGoodsAmount);
            Assert.AreEqual(90m, cart.TotalAmount);
            A.CallTo(() => promotionsCalculator.CalculateTotalDiscount(cart)).MustHaveHappenedOnceExactly();
        }

        [Test]
        public void Should_account_for_shipping()
        {
            //Arrange
            var cart = new Cart()
            {
                Address = new Address(),
                LineItems = new List<LineItem>()
                {
                    new LineItem() {SkuId = 1, Count = 1, UnitPrice = 100}
                }
            };

            var promotionsCalculator = A.Fake<IPromotionsCalculator>();
            var shippingCalculator = A.Fake<IShippingCalculator>();
            A.CallTo(() => shippingCalculator.CalculateShipping(null)).WithAnyArguments().Returns(10);
            var taxCalculator = A.Fake<ITaxCalculator>();
            var totalsCalculator = new TotalsCalculator(promotionsCalculator, shippingCalculator, taxCalculator);

            //Act
            totalsCalculator.CalculateTotals(cart);

            //Assert
            Assert.AreEqual(10m, cart.ShippingCost);
            Assert.AreEqual(110m, cart.TotalAmount);
            A.CallTo(() => shippingCalculator.CalculateShipping(cart)).MustHaveHappenedOnceExactly();
        }

        [Test]
        public void Should_account_for_tax()
        {
            //Arrange
            var cart = new Cart()
            {
                Address = new Address(),
                LineItems = new List<LineItem>()
                {
                    new LineItem() {SkuId = 1, Count = 1, UnitPrice = 100}
                }
            };

            var promotionsCalculator = A.Fake<IPromotionsCalculator>();
            var shippingCalculator = A.Fake<IShippingCalculator>();
            var taxCalculator = A.Fake<ITaxCalculator>();
            A.CallTo(() => taxCalculator.CalculateTaxes(null)).WithAnyArguments().Returns(10);
            var totalsCalculator = new TotalsCalculator(promotionsCalculator, shippingCalculator, taxCalculator);

            //Act
            totalsCalculator.CalculateTotals(cart);

            //Assert
            Assert.AreEqual(10m, cart.Tax);
            Assert.AreEqual(110m, cart.TotalAmount);
            A.CallTo(() => taxCalculator.CalculateTaxes(cart)).MustHaveHappenedOnceExactly();
        }
    }
}
