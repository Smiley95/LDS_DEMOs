using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BL.Repositories
{
    public class OrderItemRepository
    {
        public OrderItem retrieve(int ID)
        {
            return new OrderItem(ID);
        }
        public bool Save(OrderItem orderItem)
        {
            if (orderItem.HasChanges && orderItem.IsValid)
            {
                if (orderItem.IsNew)
                {

                }
                else
                {

                }
            }
            return true;
        }
    }
}
