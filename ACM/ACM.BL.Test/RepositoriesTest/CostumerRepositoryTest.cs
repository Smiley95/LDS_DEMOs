using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ACM.BL.Repositories;

namespace ACM.BL.Test.RepositoriesTest
{
    [TestClass]
    public class CostumerRepositoryTest
    {
        [TestMethod]
        public void retrieveCostumerTest()
        {
            //Arrange
            CostumerRepository costumerRepository = new CostumerRepository();
            var expected = new Costumer(0);
            //Assert
            //if you compare the 2 objects you'll get a wrong output because they don't refer the same object
            //you have to comapre each property 
            Assert.AreEqual(costumerRepository.retrieve(0).CostumerID, expected.CostumerID);
        }
        [TestMethod]
        public void SavingTest()
        {
            //Arrange
            CostumerRepository costumerRepository = new CostumerRepository();
            //Assert
            Assert.IsTrue(costumerRepository.Save());
        }
    }
}
