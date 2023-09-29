using System;
using System.Collections.Generic;

namespace Ecommerce_Repository.DBContext.Core;

public partial class Category
{
    public Guid Categoryid { get; set; }

    public string? Categoryname { get; set; }

    public virtual ICollection<Product> Products { get; set; } = new List<Product>();
}
