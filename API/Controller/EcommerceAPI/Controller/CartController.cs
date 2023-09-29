
using Ecommerce_BL.Interface;


namespace EcommerceAPI.Controller
{
  
    public class CartController : BaseController
    {
        private readonly ICartOrderBL _CARTORDERBL;
        public CartController(ICartOrderBL cartOrderBL)
        {
            _CARTORDERBL = cartOrderBL;
        }
       
    }
}
