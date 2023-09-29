#region namespaces
using Ecommerce_Repository.Models;
#endregion
namespace Ecommerce_Repository.IRepository
{
    public interface IAdminRepository
    {
        Task<String> ValidateUser(LoginDM login);
        Task<String> SignUp(NewUserDM newUserBM);
    }
}
