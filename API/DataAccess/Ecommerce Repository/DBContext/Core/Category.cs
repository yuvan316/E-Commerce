﻿using System;
using System.Collections.Generic;

namespace Ecommerce_Repository.DBContext.Core;

public partial class Category
{
    public Guid Categoryid { get; set; }

    public string? Categoryname { get; set; }

    public DateTime? Createdon { get; set; }

    public string? Createdby { get; set; }

    public string? Lastupdatedby { get; set; }

    public DateTime? Modifiedon { get; set; }

    public virtual ICollection<Brand> Brands { get; set; } = new List<Brand>();
}
