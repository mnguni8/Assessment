using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCSVReader
{
    public class PersonData
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Address { get; set; }

        public string AddressName
        {
            get { return this.Address.Split(null)[1]; }
        }

        public string PhoneNumber { get; set; }

        public int FirstNameFrequency { get; set; }

        public string FirstAndLastName
        {
            get { return this.FirstName + " " + this.LastName; }
        }
    }
}
