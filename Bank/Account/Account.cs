﻿using System;
using System.Threading.Tasks;

namespace BankAccount
{
    public class Account
    {
        public int ID;
        public string holder { get; set; }
        public double overdraftLimit { get; set; }
        public double balance { get; set; }
        public bool blocked = false;
        public  double dailyWireTransferLimit { get; set; }
        public Account(int ID, string holder)
        {
            this.ID = ID;
            this.holder = holder;
        }
        public async Task DeposeCheque(double funds)
        {
            if (funds <= 0) throw new Exception("Invalid fund input");
            if (balance + funds <= 0) return;
            if (DateTime.Today.DayOfWeek == DayOfWeek.Friday)
            {
                await Task.Delay(DateTime.Today.AddDays(3).AddHours(9) - DateTime.Now);
                balance += funds;
                blocked = false;
            }
            else
            {
                await Task.Delay(DateTime.Today.AddDays(1).AddHours(9) - DateTime.Now);
                balance += funds;
                blocked = false;
            }
        }
        public void DeposeCash(double funds)
        {
            if (balance + funds <= 0) return;
            if (funds <= 0) throw new Exception("Invalid fund input");
            blocked = false;
            balance += funds;
        }
        public void WithdrawCash(double funds)
        {
            if (blocked) return;
            if (funds <= 0 ) throw new Exception("Invalid fund input");
            if(Math.Abs(balance - funds) > overdraftLimit)
            {
                blocked = true;
                return;
            }
            balance -= funds;
        }
        public void WireTransfer(double funds)
        {
            if (blocked) return;
            if (funds <= 0 ) throw new Exception("Invalid fund input");
            if (funds> dailyWireTransferLimit || Math.Abs(balance-funds)>overdraftLimit)
            {
                blocked = true;
                return;
            }
            balance -= funds;
        }
    }   
}