using BankAccount;
using System;
using System.Threading.Tasks;


namespace AccountTest
{
    using Xunit;
    public class AccountTest
    {
        [Trait("Category", "construction")]
        [Fact]
        public void CanCreateAccount()
        {
            var account = new Account(4,"someone");
            Assert.NotNull(account);
        }
        [Trait("Category", "construction")]
        [Fact]
        public void CanSetOverdraftLimit()
        {
            var account = new Account(4, "someone");
            account.OverdraftLimit = 10000;
            Assert.Equal(10000,account.OverdraftLimit);
        }
        [Trait("Category", "construction")]
        [Fact]
        public void CanSetDailyWireTransferLimit()
        {
            var account = new Account(4, "someone");
            account.dailyWireTransferLimit = 10000;
            Assert.Equal(10000, account.dailyWireTransferLimit);
        }
        [Trait("Category", "Dispose")]
        [Fact]
        public async Task CanDeposeChequeToAccount()
        {
            var account = new Account(4, "someone");
            await account.DeposeCheque(40000);
            Assert.Equal(40000, account.Balance);
        }
        [Trait("Category", "Dispose")]
        [Fact]
        public void CanDeposeCashToAccount()
        {
            var account = new Account(4, "someone");
            account.DeposeCash(40000);
            Assert.Equal(40000, account.Balance);
        }
        [Trait("Category", "valid input")]
        [Fact]
        public void CanDeposeValidCashInput()
        {
            var account = new Account(4, "someone");
            Assert.Throws<Exception>(() => account.DeposeCash(0));
        }
        [Trait("Category", "Withdraw")]
        [Fact]
        public void CanWithdrawCashFromAccount()
        {
            var account = new Account(4, "someone");
            account.DeposeCash(40000);
            account.WithdrawCash(5000);
            Assert.Equal(35000, account.Balance);
        }
        [Trait("Category", "valid input")]
        [Fact]
        public void CanWithdrawValidCashInput()
        {
            var account = new Account(4, "someone");
            account.Balance = 1000;
            Assert.Throws<Exception>(() => account.WithdrawCash(0));
            account.WithdrawCash(2000);
            Assert.True(account.Blocked);
        }
        [Trait("Category", "Withdraw")]
        [Fact]
        public void CanWithdrawWireTransfer()
        {
            var account = new Account(4, "someone");
            account.Balance = 4000;
            account.dailyWireTransferLimit = 1000;
            account.WireTransfer(1000);
            Assert.Equal(3000,account.Balance);
        }
        [Trait("Category", "valid input")]
        [Fact]
        public void CanWireTransferWithdrawValidAmount()
        {
            var account = new Account(4, "someone");
            account.Balance = 1000;
            Assert.Throws<Exception>(() => account.WithdrawCash(0));
            account.WithdrawCash(2000);
            Assert.True(account.Blocked);
        }
        [Trait("Category", "Blocked")]
        [Fact]
        public void CanWireTransferDontChangeIfAccountIsBlocked()
        {
            var account = new Account(4, "someone");
            account.Balance = 1000;
            account.dailyWireTransferLimit = 600;
            account.Blocked = true;
            account.WireTransfer(500);
            Assert.Equal(1000, account.Balance);
        }
        [Trait("Category", "Blocked")]
        [Fact]
        public void CanWireTransferBlock()
        {
            var account = new Account(4, "someone");
            account.Balance = 1000;
            account.dailyWireTransferLimit = 500;
            account.WireTransfer(600);
            Assert.True(account.Blocked);
            Assert.Equal(1000, account.Balance);
        }
        [Trait("Category", "Blocked")]
        [Fact]
        public void CanNotExceedOverdraftLimitToWithdrawCash()
        {
            var account = new Account(4,"someone");
            account.Balance = 1000;
            account.WithdrawCash(1501);
            Assert.True(account.Blocked);
            Assert.Equal(1000, account.Balance);
        }
        [Trait("Category", "Blocked")]
        [Fact]
        public void CanNotExceedOverdraftLimitToWithdrawWireTransfer()
        {
            var account = new Account(4, "someone");
            account.Balance = 1000;
            account.dailyWireTransferLimit = 2000;
            account.WireTransfer(1501);
            Assert.True(account.Blocked);
            Assert.Equal(1000,account.Balance);
        }
        [Trait("Category", "Unblock")]
        [Fact]
        public void CanDisposeCashUnblockAccount()
        {
            var account = new Account(4, "someone");
            account.Balance = 1000;
            account.WithdrawCash(1501);
            Assert.True(account.Blocked);
            Assert.Equal(1000, account.Balance);
            account.DeposeCash(400);
            Assert.False(account.Blocked);
            Assert.Equal(1400, account.Balance);
        }
        [Trait("Category", "Unblock")]
        [Fact]
        public async Task CanDisposeChequeUnblockAccount()
        {
            var account = new Account(4, "someone");
            account.Balance = 1000;
            account.WithdrawCash(1501);
            Assert.True(account.Blocked);
            Assert.Equal(1000, account.Balance);
            await account.DeposeCheque(400);
            Assert.False(account.Blocked);
            Assert.Equal(1400, account.Balance);
        }
    }
}
