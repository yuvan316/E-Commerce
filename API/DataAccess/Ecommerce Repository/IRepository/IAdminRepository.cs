#region namespaces
using Ecommerce_Repository.Models;
#endregion

namespace Ecommerce_Repository.IRepository
{
    public interface IAdminRepository
    {
        #region method declarations
        Task<String> ValidateUser(LoginDM login);
        Task<String> SignUp(NewUserDM newUserDM);
        #endregion
    }
}
