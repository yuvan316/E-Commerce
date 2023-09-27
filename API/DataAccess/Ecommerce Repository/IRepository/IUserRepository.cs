#region namespaces
using Ecommerce_Repository.Models;
#endregion
namespace Ecommerce_Repository.IRepository
{
    public interface IUserRepository
    {
        Task<String> ValidateUser(LoginDM login);
    }
}
