using System;
using System.Collections.Generic;

namespace Ecommerce_Repository.DBContext.Admin
{
    public partial class AdminUser
    {
        public AdminUser()
        {
            AdminAuditLogs = new HashSet<AdminAuditLog>();
            AdminUserRoles = new HashSet<AdminUserRole>();
        }

        public int AdminUserId { get; set; }
        public string FirstName { get; set; } = null!;
        public string LastName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public string PasswordHash { get; set; } = null!;

        public virtual ICollection<AdminAuditLog> AdminAuditLogs { get; set; }
        public virtual ICollection<AdminUserRole> AdminUserRoles { get; set; }
    }
}
