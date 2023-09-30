#region namespaces
using Ecommerce_BL.BusinessDomain.Models;
using Ecommerce_BL.Interface;
using Ecommerce_Repository.IRepository;
using Ecommerce_Repository.Models;
using Mapster;
using Serilog;
#endregion

namespace Ecommerce_BL.BusinessDomain
{
    public class UserBL : IUserBL
    {
        #region readonly fields
        private readonly IUserRepository _USERREPOSITORY;
        #endregion
        public UserBL(IUserRepository userRepository)
        {
            _USERREPOSITORY = userRepository;
        }

        public async Task<String> ValidateUser(LoginBM loginBM)
        {
            Log.Information("Ecommerce: UserBL: ValidateUser: Started");

            var loginDM = loginBM.Adapt<LoginDM>();
            var isSuccess = await _USERREPOSITORY.ValidateUser(loginDM);
            Log.Information("Ecommerce: UserBL: ValidateUser: Completed");
            return await Task.FromResult(isSuccess);
        }
        public async Task<String> SignUp(NewUserBM newUser)
        {
            Log.Information("Ecommerce: UserBL: SignUp: Started");
            var newUserDM = newUser.Adapt<NewUserDM>();
            var status = await _USERREPOSITORY.SignUp(newUserDM);
            Log.Information("Ecommerce: UserBL: SignUp: Completed");
            return await Task.FromResult(status);
        }
        public async Task<String> SetCustomerAddress(AddressBM addressBM)
        {
            Log.Information("Ecommerce: UserBL: SignUp: Started");
            var addressDM = addressBM.Adapt<CustomerAddressDM>();
            var status = await _USERREPOSITORY.SetCustomerAddress(addressDM);
            Log.Information("Ecommerce: UserBL: SignUp: Completed");
            return await Task.FromResult(status);
        }
    }
}
