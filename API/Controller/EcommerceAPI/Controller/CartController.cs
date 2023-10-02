#region namespaces
using Ecommerce_BL.Interface;
#endregion

namespace EcommerceAPI.Controller
{
  
    public class CartController : BaseController
    {
        #region readonly fields
        private readonly ICartOrderBL _CARTORDERBL;
        #endregion

        #region constructor
        public CartController(ICartOrderBL cartOrderBL)
        {
            _CARTORDERBL = cartOrderBL;
        }
        #endregion

        #region methods
        #endregion

    }
}
