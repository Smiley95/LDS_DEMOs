using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ACM.BL.Repositories;

namespace ACM.BL.Test.RepositoriesTest
{
    [TestClass]
    public class ProductRepositoryTest
    {
        [TestMethod]
        public void SavingTest()
        {
            //Arrange
            ProductRepository productRepository = new ProductRepository();
            //Assert
            Assert.IsTrue(productRepository.Save());
        }
        [TestMethod]
        public void retrieveProductTest()
        {
            //Arrange
            ProductRepository productRepository = new ProductRepository();
            var expected = new Product(0);
            //Assert
            //if you compare the 2 objects you'll get a wrong output because they don't refer the same object
            //you have to comapre each property 
            Assert.AreEqual(productRepository.retrieve(0).ProductID, expected.ProductID);
        }
    }
}
