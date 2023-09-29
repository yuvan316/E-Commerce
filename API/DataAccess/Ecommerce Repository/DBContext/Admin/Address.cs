using System;
using System.Collections.Generic;

namespace Ecommerce_Repository.DBContext.Admin;

public partial class Address
{
    public Guid Addressid { get; set; }

    public Guid? Customerid { get; set; }

    public string? Streetaddress { get; set; }

    public string? City { get; set; }

    public virtual Customer? Customer { get; set; }
}
