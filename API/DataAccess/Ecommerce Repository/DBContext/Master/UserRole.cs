using System;
using System.Collections.Generic;

namespace Ecommerce_Repository.DBContext.Master;

public partial class Userrole
{
    public Guid Userroleid { get; set; }

    public string? Rolename { get; set; }
}
