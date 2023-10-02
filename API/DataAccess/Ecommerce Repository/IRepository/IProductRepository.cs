#region namespaces
using Ecommerce_Repository.Models;
#endregion

namespace Ecommerce_Repository.IRepository
{
    public interface IProductRepository
    {
        #region methodDeclarations
        Task<List<CategoryDM>> Categories();
        Task<List<BrandDM>> Brands(String CategoryId);
        Task<List<ProductDM>> Products(String ProductId);
        #endregion
    }
}
