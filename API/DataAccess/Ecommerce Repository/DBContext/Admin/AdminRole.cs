using System;
using System.Collections.Generic;

namespace Ecommerce_Repository.DBContext.Admin
{
    public partial class AdminRole
    {
        public AdminRole()
        {
            AdminUserRoles = new HashSet<AdminUserRole>();
        }

        public int AdminRoleId { get; set; }
        public string RoleName { get; set; } = null!;

        public virtual ICollection<AdminUserRole> AdminUserRoles { get; set; }
    }
}
