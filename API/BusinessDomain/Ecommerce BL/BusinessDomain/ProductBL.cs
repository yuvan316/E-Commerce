using Ecommerce_BL.BusinessDomain.Models;
using Ecommerce_BL.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_BL.BusinessDomain
{
    public class ProductBL:IProductBL
    {
        public async Task<CategoryBM> GetCategories()
        {
            CategoryBM categoryBM = null;
            return categoryBM;
        }
    }
}
