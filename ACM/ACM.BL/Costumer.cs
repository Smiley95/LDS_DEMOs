//naming convention: CamelCase
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BL
{
    public class Costumer
    {
        public static int CostumerCount = 0;
        public int CostumerID { get; private set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string _FullName
        {
            get
            {
                return FirstName + ", " + LastName;
            }
        }
        public void countCustomers() { CostumerCount++; }
        public bool Validate()
        {
            return (string.IsNullOrWhiteSpace(FirstName)|| string.IsNullOrWhiteSpace(LastName)|| string.IsNullOrWhiteSpace(EmailAddress))?  false: true;
        }
    }
}
