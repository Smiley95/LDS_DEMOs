using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ACM.BL.Repositories;

namespace ACM.BL.Test.RepositoriesTest
{
    [TestClass]
    public class AddressRepositoryTest
    {
        [TestMethod]
        public void SavingTest()
        {
            //Arrange
            AddressRepository addressRepository = new AddressRepository();
            //Assert
            Assert.IsTrue(addressRepository.Save());
        }
        [TestMethod]
        public void retrieveAddressTest()
        {
            //Arrange
            AddressRepository addressRepository = new AddressRepository();
            var expected = new Address(0);
            //Assert
            //if you compare the 2 objects you'll get a wrong output because they don't refer the same object
            //you have to comapre each property 
            Assert.AreEqual(addressRepository.retrieve(0).AddressID, expected.AddressID);
        }
    }
}
