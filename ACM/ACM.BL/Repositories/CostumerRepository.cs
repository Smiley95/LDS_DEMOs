using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BL.Repositories
{
    public class CostumerRepository
    {
        public Costumer retrieve(int ID)
        {
            return new Costumer(ID);
        }
        public bool Save(Costumer costumer)
        {
            if (costumer.HasChanges && costumer.IsValid)
            {
                if (costumer.IsNew)
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
