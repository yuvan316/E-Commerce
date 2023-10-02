#region namespaces
using Ecommerce_BL.BusinessDomain.Models;
#endregion

namespace Ecommerce_BL.Interface
{
    public interface IAdminBL
    {
        #region method declarations
        Task<String> SignUp(NewUserBM newUserBM);
        #endregion
    }
}
