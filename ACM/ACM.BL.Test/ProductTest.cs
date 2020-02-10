using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ACM.BL.Test
{
    [TestClass]
    public class ProductTest
    {
        [TestMethod]
        public void ValidInputsTest()
        {
            //Arrange
            Product productRight = new Product(2, "potato", "food", 1.8);
            Product ProductWrong = new Product(3, "tomato", null, 0);
            //Assert
            Assert.IsTrue(productRight.Validate());
            Assert.IsFalse(ProductWrong.Validate());
        }
        
    }
}
