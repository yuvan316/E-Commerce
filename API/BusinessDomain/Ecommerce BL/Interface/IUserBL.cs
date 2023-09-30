#region namespaces
using Ecommerce_BL.BusinessDomain.Models;
using Ecommerce_Repository.Models;
#endregion

namespace Ecommerce_BL.Interface
{
    public interface IUserBL
    {
        Task<String> ValidateUser(LoginBM loginBM);
        Task<String> SignUp(NewUserBM newUser);

        Task<String> SetCustomerAddress(AddressBM addressBM);
    }
}
