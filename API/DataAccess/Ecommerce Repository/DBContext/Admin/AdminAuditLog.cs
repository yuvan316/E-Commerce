using System;
using System.Collections.Generic;

namespace Ecommerce_Repository.DBContext.Admin
{
    public partial class AdminAuditLog
    {
        public int AuditLogId { get; set; }
        public int? AdminUserId { get; set; }
        public string Action { get; set; } = null!;
        public DateTime Timestamp { get; set; }

        public virtual AdminUser? AdminUser { get; set; }
    }
}
