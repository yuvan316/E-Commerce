using System;
using System.Collections.Generic;

namespace Ecommerce_Repository.DBContext.Core;

public partial class Image
{
    public Guid Imageid { get; set; }

    public string Entitytype { get; set; } = null!;

    public Guid Entityid { get; set; }

    public string Filename { get; set; } = null!;

    public int Filesize { get; set; }

    public byte[] Imagedata { get; set; } = null!;

    public DateTime Uploaddate { get; set; }

    public DateTime? Createdon { get; set; }

    public string? Createdby { get; set; }

    public string? Lastupdatedby { get; set; }

    public DateTime? Modifiedon { get; set; }
}
