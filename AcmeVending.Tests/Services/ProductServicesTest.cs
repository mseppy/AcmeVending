using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;
using System.Collections.Generic;
using AcmeVending.Domain;
using AcmeVending.Domain.Interfaces;
using AcmeVending.Services;
using System.Linq;
using System;

namespace AcmeVending.Tests.Services
{
    [TestClass]
    public class ProductsServicesTest
    {

        IProductService classUnderTest = new ProductService();


        public ProductsServicesTest()
        {
        }

        [TestMethod]
        public void BuyProduct_InvalidID()
        {
            var prodId = 123533532;
            var cash = 1.25M;

            var result = classUnderTest.BuyProduct(prodId, cash);

            Assert.IsNotNull(result);
            Assert.AreEqual("SOLD OUT", result.ErrorMessage);
        }

        [TestMethod]
        public void BuyProduct_InvalidCash()
        {
            var prodId = 6;
            var cash = 0.25M;

            var result = classUnderTest.BuyProduct(prodId, cash);

            Assert.IsNotNull(result);
            Assert.AreEqual("NSF", result.ErrorMessage);
        }

        [TestMethod]
        public void BuyProduct_ProductSoldOut()
        {
            var prodId = 6;
            var cash = 1M;

            var expected = new List<Product> { new Product { ItemNumber = prodId, Quantity = 0 } };
            classUnderTest = new ProductService() { ProductRepo = expected };
            var result = classUnderTest.BuyProduct(prodId, cash);

            Assert.IsNotNull(result);
            Assert.AreEqual("SOLD OUT", result.ErrorMessage);
        }


        [TestMethod]
        public void BuyProduct_CorrectChange()
        {
            var prodId = 6;
            var cash = .5M;
            var expectedQty = classUnderTest.SelectProduct(prodId).Quantity - 1;

            var result = classUnderTest.BuyProduct(prodId, cash);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Result);
            Assert.IsNull(result.ErrorMessage);
            Assert.AreEqual(expectedQty, classUnderTest.SelectProduct(prodId).Quantity);
        }


        [TestMethod]
        public void BuyProduct_NeedChange()
        {
            var prodId = 6;
            var cash = 1M;
            var expectedChange = .5M;

            var result = classUnderTest.BuyProduct(prodId, cash);

            Assert.IsNotNull(result);
            Assert.IsTrue(result.Result);
            Assert.IsNull(result.ErrorMessage);
            Assert.AreEqual(expectedChange, result.Change);
        }
    }
}
