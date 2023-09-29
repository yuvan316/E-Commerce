using System;
using System.Collections.Generic;

namespace Ecommerce_Repository.DBContext.Core;

public partial class Product
{
    public Guid Productid { get; set; }

    public Guid? Categoryid { get; set; }

    public Guid? Userid { get; set; }

    public string? Productname { get; set; }

    public decimal? Price { get; set; }

    public virtual ICollection<Cart> Carts { get; set; } = new List<Cart>();

    public virtual Category? Category { get; set; }

    public virtual ICollection<Orderitem> Orderitems { get; set; } = new List<Orderitem>();

    public virtual ICollection<Review> Reviews { get; set; } = new List<Review>();
}
