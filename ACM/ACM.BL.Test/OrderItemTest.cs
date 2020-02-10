using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ACM.BL.Test
{
    [TestClass]
    public class OrderItemTest
    {
        [TestMethod]
        public void ValidInputsTest()
        {
            //Arrange
            OrderItem RightOrderItem = new OrderItem(1,2,20,53.2);
            OrderItem WrongOrderItem = new OrderItem(1, 2, 20,0);
            //Assert
            Assert.IsTrue(RightOrderItem.Validate());
            Assert.IsFalse(WrongOrderItem.Validate());
        }
        [TestMethod]
        public void SavingTest()
        {
            //Arrange
            OrderItem orderItem = new OrderItem(3);
            //Assert
            Assert.IsTrue(orderItem.Save());
        }
    }
}
