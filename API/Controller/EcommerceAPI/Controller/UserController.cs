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
        public UserController(IUserBL userBL) {
        _IUSERBL = userBL;
        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login([FromBody] LoginBM login)
        {
            var isSuccess = _IUSERBL.ValidateUser(login);
            return Ok(isSuccess);
        }

    }
}
