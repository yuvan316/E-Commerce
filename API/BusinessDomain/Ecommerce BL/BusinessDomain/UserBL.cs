#region namespaces
using Ecommerce_BL.BusinessDomain.Models;
using Ecommerce_BL.Interface;
using Ecommerce_Repository.IRepository;
using Ecommerce_Repository.Models;
using Mapster;
#endregion

namespace Ecommerce_BL.BusinessDomain
{
    public class UserBL : IUserBL
    {
        #region readonly fields
        private readonly IUserRepository _IUSERREPOSITORY;
        #endregion
        public UserBL(IUserRepository userRepository)
        {
            _IUSERREPOSITORY = userRepository;
        }

        public async Task<String> ValidateUser(LoginBM loginBM)
        {

            var loginDM = loginBM.Adapt<LoginDM>();
            var isSuccess = await _IUSERREPOSITORY.ValidateUser(loginDM);
            return await Task.FromResult(isSuccess);
        }
    }
}
