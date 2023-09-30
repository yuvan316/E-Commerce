#region namespaces
using Ecommerce_BL.BusinessDomain.Models;
using Ecommerce_BL.Interface;
using Microsoft.AspNetCore.Mvc;
using Serilog;
#endregion
namespace EcommerceAPI.Controller
{
    public class UserController : BaseController
    {
        #region readonly fields
        private readonly IUserBL _USERBL;
        #endregion
        #region constructor
        public UserController(IUserBL userBL) {
        _USERBL = userBL;
        }
        #endregion
        #region methods
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginBM login)
        {
            Log.Information("Ecommerce: UserController: Login: Started");
            var isSuccess =await _USERBL.ValidateUser(login);
            Log.Information("Ecommerce: UserController: Login: Started");
            return Ok(isSuccess);
        }
        [HttpPost]
        [Route("SignUp")]
        public async Task<IActionResult> SignUp([FromBody] NewUserBM newUser)
        {
            Log.Information("Ecommerce: UserController: SignUp: Started");
            var status=await _USERBL.SignUp(newUser);
            Log.Information("Ecommerce: UserController: SignUp: Started");
            return Ok(status);

        }
        [HttpPost]
        [Route("SetCustomerAddress")]
        public async Task<IActionResult> SetCustomerAddress([FromBody] AddressBM addressBM)
        {
            Log.Information("Ecommerce: UserController: SetCustomerAddress: Started");
            var status = await _USERBL.SetCustomerAddress(addressBM);
            Log.Information("Ecommerce: UserController: SetCustomerAddress: Started");
            return Ok(status);
        }
        #endregion
    }
}
