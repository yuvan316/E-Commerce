using System;
using System.Collections.Generic;

namespace Ecommerce_Repository.DBContext.Core;

public partial class Review
{
    public Guid Reviewid { get; set; }

    public Guid? Productid { get; set; }

    public Guid? Customerid { get; set; }

    public int? Rating { get; set; }

    public string? Reviewtext { get; set; }

    public DateTime? Createdon { get; set; }

    public string? Createdby { get; set; }

    public string? Lastupdatedby { get; set; }

    public DateTime? Modifiedon { get; set; }

    public virtual Product? Product { get; set; }
}
