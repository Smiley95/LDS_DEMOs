

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
    }   

}
