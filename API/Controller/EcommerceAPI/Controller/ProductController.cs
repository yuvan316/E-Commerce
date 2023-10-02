#region namespaces
#endregion

using Ecommerce_BL.Interface;
using Microsoft.AspNetCore.Mvc;

namespace EcommerceAPI.Controller
{
   
    public class ProductController : BaseController
    {
        private readonly IProductBL _PRODUCTBL;
        
        #region constructor
        public ProductController(IProductBL productBL)
        {
           _PRODUCTBL = productBL;
        }
        #endregion
        #region methods
     
        #endregion
    }


}
