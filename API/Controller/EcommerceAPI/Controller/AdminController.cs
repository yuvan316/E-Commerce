﻿#region namespaces
using Ecommerce_BL.BusinessDomain.Models;
using Ecommerce_BL.Interface;
using Microsoft.AspNetCore.Mvc;
#endregion



namespace EcommerceAPI.Controller
{
  
   
    public class AdminController : BaseController
    {
        #region readonly fields
        private readonly IUserBL _USERBL;
        #endregion
        #region constructor
        public AdminController(IUserBL userBL)
        {
            _USERBL = userBL;
        }
        #endregion
        #region methods
        [HttpPost]
        [Route("SignUp")]
        public async Task<String> SignUp(NewUserBM newUserBM)
        {
            return ("");
        }
        #endregion
    }

}
