using System;
using System.Collections.Generic;

namespace Ecommerce_Repository.DBContext.Master
{
    public partial class UserRole
    {
        public int RoleId { get; set; }
        public string RoleName { get; set; } = null!;
    }
}
