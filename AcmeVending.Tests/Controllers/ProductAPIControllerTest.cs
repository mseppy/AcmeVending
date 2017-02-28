using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using AcmeVending.Models;
using AcmeVending.Controllers;

namespace AcmeVending.Tests.Controllers
{
    [TestClass]
    public class ProductAPIControllerTest
    {
        [TestMethod]
        public void Get()
        {
            // Arrange
            ProductAPIController controller = new ProductAPIController();

            // Act
            IEnumerable<ProductVM> result = controller.Get();

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(10, result.Count());
        }

        [TestMethod]
        public void GetById()
        {
            // Arrange
            ProductAPIController controller = new ProductAPIController();

            // Act
            ProductVM result = controller.Get(5);

            // Assert
            Assert.AreEqual("Product 5", result.Name);
        }

        [TestMethod]
        public void Post()
        {
            // Arrange
            ProductAPIController controller = new ProductAPIController();

            // Act
            controller.Post("value");

            // Assert
        }

        [TestMethod]
        public void Put()
        {
            // Arrange
            ProductAPIController controller = new ProductAPIController();

            // Act
            controller.Put(5, "value");

            // Assert
        }

        [TestMethod]
        public void Delete()
        {
            // Arrange
            ProductAPIController controller = new ProductAPIController();

            // Act
            controller.Delete(5);

            // Assert
        }
    }
}
