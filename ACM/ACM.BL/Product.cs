using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BL
{
    public class Product
    {
        public int ProductID { get; private set; }
        public string ProductName { get; set; }
        public string Description { get; set; }
        public double CurrentPrice { get; set; }
        public Product(int ID)
        {
            ProductID = ID;
        }
        public Product(int ID,string productName, string description, double currentPrice)
        {
            ProductName = productName;
            Description = description;
            CurrentPrice = currentPrice;
            ProductID = ID;
        }
        public bool Validate()
        {
            return (string.IsNullOrWhiteSpace(ProductName) || string.IsNullOrWhiteSpace(Description) || CurrentPrice==0) ? false : true;
        }
    }
}
