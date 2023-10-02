using System;
using System.Collections.Generic;

namespace Ecommerce_Repository.DBContext.Admin;

public partial class Customer
{
    public Guid Customerid { get; set; }

    public string? Firstname { get; set; }

    public string? Lastname { get; set; }

    public string? Email { get; set; }

    public string? Passwordhash { get; set; }

    public DateTime? Createdon { get; set; }

    public string? Createdby { get; set; }

    public string? Lastupdatedby { get; set; }

    public DateTime? Modifiedon { get; set; }

    public virtual ICollection<Address> Addresses { get; set; } = new List<Address>();
}
