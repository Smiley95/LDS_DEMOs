// Naming convention : CamelCase
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BL
{
    public class OrderItem
    {
        public int OrderItemID { get; private set; }
        public int?  ProductID { get; set; }
        public int? Quantity { get; set; }
        public double PurchasePrice { get; set; }
        public OrderItem(int ID)
        {
            OrderItemID = ID;
        }
        public OrderItem(int ID, int productID, int quantity, double purchasePrice)
        {
            OrderItemID = ID;
            ProductID = productID;
            Quantity = quantity;
            PurchasePrice = purchasePrice;
        }
        public bool Validate()
        {
            return (ProductID == null || Quantity == 0||  Quantity == null || PurchasePrice == 0) ? false : true;
        }

        public OrderItem retrieve(int ID)
        {
            return new OrderItem(ID);
        }
        public bool Save()
        {
            return true;
        }


    }
}
