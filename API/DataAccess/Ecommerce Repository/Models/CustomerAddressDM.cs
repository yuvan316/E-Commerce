using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_Repository.Models
{
    public class CustomerAddressDM
    {
        public Int64 HouseNo { get; set; }
        public String StreetOrArea { get; set; }
        public String City { get; set; }
        public String Landmark { get; set; }
        public Double PinCode { get; set; }
        public String Country { get; set; }
        public String CustomerId { get; set; }

    }
}
