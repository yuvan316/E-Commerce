﻿using System;
using System.Collections.Generic;

namespace Ecommerce_Repository.DBContext.Core;

public partial class Order
{
    public Guid Orderid { get; set; }

    public Guid? Customerid { get; set; }

    public DateTime? Orderdate { get; set; }

    public DateTime? Createdon { get; set; }

    public string? Createdby { get; set; }

    public string? Lastupdatedby { get; set; }

    public DateTime? Modifiedon { get; set; }

    public virtual ICollection<Orderitem> Orderitems { get; set; } = new List<Orderitem>();

    public virtual ICollection<Shipping> Shippings { get; set; } = new List<Shipping>();
}
