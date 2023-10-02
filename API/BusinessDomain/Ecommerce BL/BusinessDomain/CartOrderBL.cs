#region namespaces
using Ecommerce_BL.Interface;
using Ecommerce_Repository.IRepository;
#endregion

namespace Ecommerce_BL.BusinessDomain
{
    public class CartOrderBL:ICartOrderBL
    {
        #region readonly fields
        private readonly ICartandOrderRepository _ICARTANDORDERREPO;
        #endregion

        #region constructor
        public CartOrderBL(ICartandOrderRepository cartandOrderRepository)
        {
            _ICARTANDORDERREPO = cartandOrderRepository;
        }
        #endregion

        #region methods
        #endregion
    }
}
