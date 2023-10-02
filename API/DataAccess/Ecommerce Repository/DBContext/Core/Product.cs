using System;
using System.Collections.Generic;

namespace Ecommerce_Repository.DBContext.Core;

public partial class Product
{
    public Guid Productid { get; set; }

    public Guid? Userid { get; set; }

    public string? Productname { get; set; }

    public decimal? Price { get; set; }

    public DateTime? Createdon { get; set; }

    public string? Createdby { get; set; }

    public string? Lastupdatedby { get; set; }

    public DateTime? Modifiedon { get; set; }

    public Guid? Brandid { get; set; }

    public virtual Brand? Brand { get; set; }

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual ICollection<Orderitem> Orderitems { get; set; } = new List<Orderitem>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
