using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_Repository.Models
{
    public class ProductDM
    {
        public Guid ProductId { get; set; }
        public String ProductName {  get; set; }    
        public String Category { get; set; }
        public Decimal Price { get; set; }
    }
}
