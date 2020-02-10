//naming convention: CamelCase
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ACM.BL.Test
{
    [TestClass]
    public class CostumerTest
    {
        [TestMethod]
        public void FullNameOutputTest()
        {
            //Arrange
            Costumer costumer = new Costumer();
            costumer.FirstName = "name";
            costumer.LastName = "family name";
            string expected = "name, family name";
            //Act 
            string actual = costumer._FullName;
            //Assert 
            Assert.AreEqual(expected,actual);
        }
        [TestMethod]
        public void CountInstanceTest()
        {
            //Arrange
            Costumer Frudo = new Costumer();
            Frudo.countCustomers();
            Costumer Lisa = new Costumer();
            Lisa.countCustomers();
            Costumer Jay = new Costumer();
            Jay.countCustomers();
            //Assert
            Assert.AreEqual(3, Costumer.CostumerCount);
        }

        [TestMethod]
        public void ValidInputsTest()
        {
            //Arrange
            Costumer costumerOne = new Costumer();
            costumerOne.FirstName = "fname";
            costumerOne.LastName = "lname";
            costumerOne.EmailAddress = "lname@fname";
            //Assert
            Assert.IsTrue(costumerOne.Validate());
        }
        

    }
}
