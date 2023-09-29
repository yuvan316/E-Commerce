using System;
using System.Collections.Generic;

namespace Ecommerce_Repository.DBContext.Core;

public partial class Orderitem
{
    public Guid Orderitemid { get; set; }

    public Guid? Orderid { get; set; }

    public Guid? Productid { get; set; }

    public int? Quantity { get; set; }

    public virtual Order? Order { get; set; }

    public virtual Product? Product { get; set; }
}
