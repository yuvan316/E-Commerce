using System;
using System.Collections.Generic;

namespace Ecommerce_Repository.DBContext.Core;

public partial class Cart
{
    public Guid Cartid { get; set; }

    public Guid? Customerid { get; set; }

    public Guid? Productid { get; set; }

    public int? Quantity { get; set; }

    public DateTime? Createdon { get; set; }

    public string? Createdby { get; set; }

    public string? Lastupdatedby { get; set; }

    public DateTime? Modifiedon { get; set; }

    public virtual Product? Product { get; set; }
}
