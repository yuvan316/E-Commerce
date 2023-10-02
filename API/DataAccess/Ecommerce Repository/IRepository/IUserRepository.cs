#region namespaces
using Ecommerce_Repository.Models;
#endregion

namespace Ecommerce_Repository.IRepository
{
    public interface IUserRepository
    {
        #region method declarations
        Task<String> ValidateUser(LoginDM login);
        Task<String> SignUp(NewUserDM newUserDM);
        Task<String> SetCustomerAddress(CustomerAddressDM customerAddressDM);
        #endregion
    }
}
