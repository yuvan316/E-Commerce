using Ecommerce_BL.Interface;
using Ecommerce_Repository.IRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_BL.BusinessDomain
{
    public class CartOrderBL:ICartOrderBL
    {
        private readonly ICartandOrderRepository _ICARTANDORDERREPO;
        public CartOrderBL(ICartandOrderRepository cartandOrderRepository)
        {
            _ICARTANDORDERREPO = cartandOrderRepository;
        }
    }
}
