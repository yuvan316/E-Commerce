using System;
using System.Collections.Generic;

namespace Ecommerce_Repository.DBContext.Admin;

public partial class AdminUser
{
    public Guid UserId { get; set; }

    public string FirstName { get; set; } = null!;

    public string LastName { get; set; } = null!;

    public string PasswordHash { get; set; } = null!;

    public string? Email { get; set; }
}
