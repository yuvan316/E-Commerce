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

        #region constructor
        public UserBL(IUserRepository userRepository)
        {
            _USERREPOSITORY = userRepository;
        }
        #endregion

        #region methods

        public async Task<String> ValidateUser(LoginBM loginBM)
        {
            Log.Information("Ecommerce: UserBL: ValidateUser: Started");
            //convert business model to data model
            var loginDM = loginBM.Adapt<LoginDM>();
            //repo method is called
            var isSuccess = await _USERREPOSITORY.ValidateUser(loginDM);
            Log.Information("Ecommerce: UserBL: ValidateUser: Completed");
            return await Task.FromResult(isSuccess);
        }

        public async Task<String> SignUp(NewUserBM newUser)
        {
            Log.Information("Ecommerce: UserBL: SignUp: Started");
            //convert business model to data model
            var newUserDM = newUser.Adapt<NewUserDM>();
            //repo method is called
            var status = await _USERREPOSITORY.SignUp(newUserDM);
            Log.Information("Ecommerce: UserBL: SignUp: Completed");
            return await Task.FromResult(status);
        }

        public async Task<String> SetCustomerAddress(AddressBM addressBM)
        {
            Log.Information("Ecommerce: UserBL: SignUp: Started");
            //convert business model to data model
            var addressDM = addressBM.Adapt<CustomerAddressDM>();
            //repo method is called
            var status = await _USERREPOSITORY.SetCustomerAddress(addressDM);
            Log.Information("Ecommerce: UserBL: SignUp: Completed");
            return await Task.FromResult(status);
        }

        #endregion
    }
}
