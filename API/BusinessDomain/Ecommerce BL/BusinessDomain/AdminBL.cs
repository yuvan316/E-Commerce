#region namespaces
using Ecommerce_BL.BusinessDomain.Models;
using Ecommerce_BL.Interface;
using Ecommerce_Repository.IRepository;
#endregion

namespace Ecommerce_BL.BusinessDomain
{
    public class AdminBL:IAdminBL
    {
        #region readonly fields
        private readonly IAdminRepository _ADMINREPOSITORY;
        #endregion
        #region constructor
        public AdminBL(IAdminRepository adminRepository)
        {
            
        }
        #endregion
        public async Task<String> SignUp(NewUserBM newUserBM)
        {
            return ("");
        }
    }
}
