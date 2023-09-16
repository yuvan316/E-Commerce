using System;
using System.Collections.Generic;

namespace Ecommerce_Repository.DBContext.Admin
{
    public partial class Address
    {
        public int AddressId { get; set; }
        public int? UserId { get; set; }
        public string Type { get; set; } = null!;
        public string StreetAddress { get; set; } = null!;
        public string City { get; set; } = null!;
        public string State { get; set; } = null!;
        public string PostalCode { get; set; } = null!;
        public string Country { get; set; } = null!;

        public virtual User? User { get; set; }
    }
}
