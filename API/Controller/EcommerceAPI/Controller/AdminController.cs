#region namespaces
using Ecommerce_BL.BusinessDomain.Models;
using Ecommerce_BL.Interface;
using Microsoft.AspNetCore.Mvc;
using Serilog;
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
        /// <summary>
        /// This method registers a new admin user
        /// </summary>
        /// <param name="newUserBM"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("SignUp")]
        public async Task<String> SignUp([FromBody] NewUserBM newUserBM)
        {
            Log.Information("Ecommerce: AdminController: SignUp: Started");
            Log.Information("Ecommerce: AdminController: SignUp: Completed");
            //business domain method invoke
            return await _ADMINBL.SignUp(newUserBM);
        }

        #endregion
    }

}
