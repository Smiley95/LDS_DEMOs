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
        public bool Save(Address address)
        {
            if (address.HasChanges && address.IsValid)
            {
                if (address.IsNew)
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
