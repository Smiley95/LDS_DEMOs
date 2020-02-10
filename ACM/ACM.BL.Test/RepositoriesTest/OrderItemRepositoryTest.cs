using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ACM.BL.Repositories;
namespace ACM.BL.Test.RepositoriesTest
{
    [TestClass]
    public class OrderItemRepositoryTest
    {

        [TestMethod]
        public void SavingTest()
        {
            //Arrange
            OrderItemRepository orderItemRepository = new OrderItemRepository();
            //Assert
            Assert.IsTrue(orderItemRepository.Save());
        }
        [TestMethod]
        public void retrieveOrderItemTest()
        {
            //Arrange
            OrderItemRepository orderItemRepository = new OrderItemRepository();
            var expected = new OrderItem(0);
            //Assert
            //if you compare the 2 objects you'll get a wrong output because they don't refer the same object
            //you have to comapre each property 
            Assert.AreEqual(orderItemRepository.retrieve(0).OrderItemID, expected.OrderItemID);
        }

    }
}
