using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BL.Repositories
{
    public class AddressRepository
    {
        public Address retrieve(int ID)
        {
            return new Address(ID);
        }
        public bool Save()
        {
            return true;
        }
    }
}
