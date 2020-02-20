using System;
using System.Threading.Tasks;

namespace BankAccount
{
    public class Account
    {
        public int ID;
        public string holder { get; set; }
        public double overdraftLimit { get; set; }
        public double balance { get; set; }
        public  double dailyWireTransferLimit { get; set; }
        public Account(int ID, string holder)
        {
            this.ID = ID;
            this.holder = holder;
        }
        public async Task DeposeCheque(double funds)
        {
            if(DateTime.Today.DayOfWeek == DayOfWeek.Friday)
            {
                await Task.Delay(DateTime.Today.AddDays(3).AddHours(9) - DateTime.Now);
                balance += funds;
            }
            else
            {
                await Task.Delay(DateTime.Today.AddDays(1).AddHours(9) - DateTime.Now);
                balance += funds;
            }
        }
        public void DeposeCash(double funds)
        {
            if (funds > 0) balance += funds;
            else throw new Exception("Invalid fund input");   
        }
        public void WithdrawCash(double funds)
        {
            if(funds > 0 && funds<= balance) balance -= funds;
            else throw new Exception("Invalid fund input");
        }
        public void WireTransfer(double funds)
        {
            if(funds > 0 && funds<= balance) balance -= funds;
            else throw new Exception("Invalid fund input");
        }
    }   
}