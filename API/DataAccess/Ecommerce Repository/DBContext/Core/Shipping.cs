using System;
using System.Collections.Generic;

namespace Ecommerce_Repository.DBContext.Core;

public partial class Shipping
{
    public Guid Shippingid { get; set; }

    public Guid? Orderid { get; set; }

    public DateTime? Shippingdate { get; set; }

    public string? Shippingaddress { get; set; }

    public DateTime? Createdon { get; set; }

    public string? Createdby { get; set; }

    public string? Lastupdatedby { get; set; }

    public DateTime? Modifiedon { get; set; }

    public virtual Order? Order { get; set; }
}
