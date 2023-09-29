using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_BL.BusinessDomain.Models
{
    public class ProductBM
    {
        public Guid ProductId { get; set; }
        public String ProductName {  get; set; }    
        public String Category { get; set; }
        public Decimal Price { get; set; }
    }
}
