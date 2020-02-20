using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;

namespace AccountTest
{
    public class AccountTest
    {
        [Fact]
        public void ShouldCreateAccount()
        {
            Account _account = new Account(4, "someone");
            Xunit.Assert.NotNull(_account);
        }
    }
}
