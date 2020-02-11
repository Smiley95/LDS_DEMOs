using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ACM.BL
{
    public class Address : BaseACM
    {
        public int AddressID { get; set; }
        public string Country { get; set; }
        public string AddressType { get; set; }
        public string PostalCode { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string[] StreetLine { get; set; }
        //start constructors
        public Address (int ID)
        {
            AddressID = ID;
        }
        public override bool Validate() => (string.IsNullOrWhiteSpace(PostalCode) || string.IsNullOrWhiteSpace(Country)|| string.IsNullOrWhiteSpace(AddressType)|| string.IsNullOrWhiteSpace(City)|| string.IsNullOrWhiteSpace(State)|| string.IsNullOrWhiteSpace(StreetLine[0])|| string.IsNullOrWhiteSpace(StreetLine[1]))? false:true;
    }
}
