using System;
using System.Collections.Generic;

namespace Ecommerce_Repository.DBContext.Core
{
    public partial class Shipping
    {
        public int ShippingId { get; set; }
        public int? OrderId { get; set; }
        public string TrackingNumber { get; set; } = null!;
        public DateTime ShippingDate { get; set; }

        public virtual Order? Order { get; set; }
    }
}
