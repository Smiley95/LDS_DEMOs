using System;
using System.Threading.Tasks;

namespace BankAccount
{
    public class Account
    {
        private int Id;
        public string Holder { get; set; }
        public double OverdraftLimit = 500;
        public double Balance { get; set; }
        public bool Blocked = false;
        public double dailyWireTransferLimit; 
        public Account(int id, string holder)
        {
            this.Id = id;
            this.Holder = holder;
        }
        public async Task DeposeCheque(double funds)
        {
            if (funds <= 0) throw new InvalidCastException();
            if (Balance + funds <= 0) return;
            if (DateTime.Today.DayOfWeek == DayOfWeek.Friday)
            {
                await Task.Delay(DateTime.Today.AddDays(3).AddHours(9) - DateTime.Now);
                Balance += funds;
                Blocked = false;
            }
            else
            {
                await Task.Delay(DateTime.Today.AddDays(1).AddHours(9) - DateTime.Now);
                Balance += funds;
                Blocked = false;
            }
        }
        public void DeposeCash(double funds)
        {
            if (funds <= 0) throw new InvalidCastException();
            if (Balance + funds <= 0) return;
            Blocked = false;
            Balance += funds;
        }
        public void WithdrawCash(double funds)
        {
            if (Blocked) return;
            if (funds <= 0 ) throw new InvalidCastException();
            if(Balance - funds < 0 && Math.Abs(Balance - funds) > OverdraftLimit)
            {
                Blocked = true;
                return;
            }
            Balance -= funds;
        }
        public void WireTransfer(double funds)
        {
            if (Blocked) return;
            if (funds <= 0 ) throw new InvalidCastException();
            if (funds> dailyWireTransferLimit || (Math.Abs(Balance-funds)> OverdraftLimit && Balance - funds < 0 ))
            {
                Blocked = true;
                return;
            }
            Balance -= funds;
        }
    }   
}