#region namespaces
using Ecommerce_BL.Interface;
#endregion

namespace EcommerceAPI.Controller
{
    public class ProductController : BaseController
    {
        #region readonly fields
        private readonly IProductBL _PRODUCTBL;
        #endregion

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
