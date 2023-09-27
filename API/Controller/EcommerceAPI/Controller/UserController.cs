#region namespaces
using Ecommerce_BL.BusinessDomain.Models;
using Ecommerce_BL.Interface;
using Microsoft.AspNetCore.Mvc;
#endregion
namespace EcommerceAPI.Controller
{
    public class UserController : BaseController
    {
        #region readonly fields
        private readonly IUserBL _IUSERBL;
        #endregion
        #region constructor
        public UserController(IUserBL userBL) {
        _IUSERBL = userBL;
        }
        #endregion
        #region methods
        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginBM login)
        {
            var isSuccess =await _IUSERBL.ValidateUser(login);
            return Ok(isSuccess);
        }
        #endregion
    }
}
