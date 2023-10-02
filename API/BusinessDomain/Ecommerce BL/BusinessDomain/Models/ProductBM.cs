#region namespaces
#endregion

namespace Ecommerce_BL.BusinessDomain.Models
{
    public class ProductBM
    {
        #region properties
        public Guid ProductId { get; set; }
        public String ProductName {  get; set; }    
        public String Category { get; set; }
        public Decimal Price { get; set; }
        #endregion
    }
}
