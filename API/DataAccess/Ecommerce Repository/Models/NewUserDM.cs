﻿#region namespaces
#endregion

namespace Ecommerce_Repository.Models
{
    public class NewUserDM
    {
        #region properties
        public String FirstName { get; set; }
        public String LastName { get; set; }
        public String Email { get; set; }
        public String Password { get; set; }
        public String Role { get; set; }
        #endregion
    }
}
