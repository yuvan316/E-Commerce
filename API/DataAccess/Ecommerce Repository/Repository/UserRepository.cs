#region namespaces
using CoreComponents.Constants;
using Ecommerce_Repository.DBContext.Admin;
using Ecommerce_Repository.IRepository;
using Ecommerce_Repository.Models;
#endregion

namespace Ecommerce_Repository.Repository
{
    public class UserRepository : IUserRepository

    {
        #region readonly fields
        private readonly AdminContext _ADMINCONTEXT;
        #endregion
        #region constructor
        public UserRepository(AdminContext adminContext)
        {
            _ADMINCONTEXT = adminContext;
        }
        #endregion
        #region methods
        public async Task<String> ValidateUser(LoginDM login)
        {
            var isAvailableUser = Constants.Invalid;
            var userDetail = _ADMINCONTEXT.Users.FirstOrDefault(x => x.Email == login.UserName && x.PasswordHash == login.Password);
            if (userDetail != null)
            {
                isAvailableUser = Constants.Valid;
            }
            return await Task.FromResult(isAvailableUser);
        }
        #endregion
    }
}
