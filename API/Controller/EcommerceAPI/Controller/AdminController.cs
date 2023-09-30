#region namespaces
using Ecommerce_BL.BusinessDomain.Models;
using Ecommerce_BL.Interface;
using Microsoft.AspNetCore.Mvc;
#endregion



namespace EcommerceAPI.Controller
{
  
   
    public class AdminController : BaseController
    {
        #region readonly fields
        private readonly IAdminBL _ADMINBL;
        #endregion
        #region constructor
        public AdminController(IAdminBL adminBL)
        {
            _ADMINBL = adminBL;
        }
        #endregion
        #region methods
        [HttpPost]
        [Route("SignUp")]
        public async Task<String> SignUp([FromBody] NewUserBM newUserBM)
        {
            return await _ADMINBL.SignUp(newUserBM);
        }
        #endregion
    }

}
