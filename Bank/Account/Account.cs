﻿

namespace BankAccount
{
    public class Account
    {
        public int ID;
        public string holder { get; set; }
        public Account(int ID, string holder)
        {
            this.ID = ID;
            this.holder = holder;
        }
    }   

}