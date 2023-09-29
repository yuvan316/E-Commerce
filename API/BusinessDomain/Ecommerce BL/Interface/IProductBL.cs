using Ecommerce_BL.BusinessDomain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_BL.Interface
{
    public interface IProductBL
    {
        Task<CategoryBM> GetCategories();

    }
}
