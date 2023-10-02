using System;
using System.Collections.Generic;

namespace Ecommerce_Repository.DBContext.Admin;

public partial class Address
{
    public Guid Addressid { get; set; }

    public Guid? Customerid { get; set; }

    public string? City { get; set; }

    public string? Streetorarea { get; set; }

    public decimal? Pincode { get; set; }

    public decimal? Houseno { get; set; }

    public string? Landmark { get; set; }

    public string? Country { get; set; }

    public DateTime? Createdon { get; set; }

    public string? Createdby { get; set; }

    public string? Lastupdatedby { get; set; }

    public DateTime? Modifiedon { get; set; }

    public virtual Customer? Customer { get; set; }
}
