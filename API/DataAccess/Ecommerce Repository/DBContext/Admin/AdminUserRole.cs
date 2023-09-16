using System;
using System.Collections.Generic;

namespace Ecommerce_Repository.DBContext.Admin
{
    public partial class AdminUserRole
    {
        public int AdminUserRoleId { get; set; }
        public int? AdminUserId { get; set; }
        public int? AdminRoleId { get; set; }

        public virtual AdminRole? AdminRole { get; set; }
        public virtual AdminUser? AdminUser { get; set; }
    }
}
