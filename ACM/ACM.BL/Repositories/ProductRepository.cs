using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BL.Repositories
{
    public class ProductRepository
    {
        public Product retrieve(int ID)
        {
            return new Product(ID);
        }
        public bool Save()
        {
            return true;
        }
    }
}
