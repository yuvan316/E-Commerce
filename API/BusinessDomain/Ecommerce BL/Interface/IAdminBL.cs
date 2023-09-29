#region namespaces
using Ecommerce_BL.BusinessDomain.Models;
#endregion

namespace Ecommerce_BL.Interface
{
    public interface IAdminBL
    {
        Task<String> SignUp(NewUserBM newUserBM);
    }
}
