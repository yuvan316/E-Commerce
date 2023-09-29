using System;
using System.Collections.Generic;

namespace Ecommerce_Repository.DBContext.Core;

public partial class Cart
{
    public Guid Cartid { get; set; }

    public Guid? Customerid { get; set; }

    public Guid? Productid { get; set; }

    public int? Quantity { get; set; }

    public virtual Product? Product { get; set; }
}
