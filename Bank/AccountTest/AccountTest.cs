using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Xunit;
using BankAccount;
using System.Threading.Tasks;

namespace AccountTest
{
    public class AccountTest
    {
        [Fact]
        public void ShouldCreateAccount()
        {
            Account _account = new Account(4,"someone");
            Xunit.Assert.NotNull(_account);
        }
        [Fact]
        public void ShouldSetOverdraftLimit()
        {
            Account _account = new Account(4, "someone");
            _account.overdraftLimit = 10000;
            Xunit.Assert.Equal(10000,_account.overdraftLimit);
        }
        [Fact]
        public void ShouldSetDailyWireTransferLimit()
        {
            Account _account = new Account(4, "someone");
            _account.dailyWireTransferLimit = 10000;
            Xunit.Assert.Equal(10000, _account.dailyWireTransferLimit);
        }
        [Fact]
        public async Task ShouldDeposeChequeToAccount()
        {
            Account _account = new Account(4, "someone");
            await _account.DeposeCheque(40000);
            Xunit.Assert.Equal(40000, _account.balance);
        }
        [Fact]
        public void ShouldDeposeCashToAccount()
        {
            Account _account = new Account(4, "someone");
            _account.DeposeCash(40000);
            Xunit.Assert.Equal(40000, _account.balance);
        }
    }
}
