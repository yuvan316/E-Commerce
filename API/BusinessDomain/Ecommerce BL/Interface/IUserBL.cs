#region namespaces
using Ecommerce_BL.BusinessDomain.Models;
#endregion

namespace Ecommerce_BL.Interface
{
    public interface IUserBL
    {
      Task<String> ValidateUser(LoginBM loginBM);
    }
}
