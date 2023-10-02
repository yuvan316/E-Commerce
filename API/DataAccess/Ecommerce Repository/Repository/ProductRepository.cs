#region namespaces
using Ecommerce_Repository.DBContext.Core;
using Ecommerce_Repository.IRepository;
using Ecommerce_Repository.Models;
using Serilog;
#endregion

namespace Ecommerce_Repository.Repository
{
    public class ProductRepository : IProductRepository
    {
        #region readonlyFields
        private readonly CoreContext _CORECONTEXT;
        #endregion

        #region constructor
        public ProductRepository(CoreContext coreContext)
        {
            _CORECONTEXT = coreContext;
        }
        #endregion

        #region methods
        public async Task<List<CategoryDM>> Categories()
        {
            Log.Information("Ecommerce: ProductRepository: Categories: Started");
            var categories = _CORECONTEXT.Categories.ToList();
            var categoriesDM = categories.Select(categoryDM => new CategoryDM
            {
                CategoryId = categoryDM.Categoryid,
                CategoryName = categoryDM.Categoryname
            }).ToList();
            Log.Information("Ecommerce: ProductRepository: Categories: Completed");
            return await Task.FromResult(categoriesDM);
        }
        public async Task<List<BrandDM>> Brands(String CategoryId)
        {
            Log.Information("Ecommerce: ProductRepository: Brands: Started");
            var brands = _CORECONTEXT.Brands.Where(x => x.Categoryid.ToString() == CategoryId).Select(brand => new BrandDM()
            {
                BrandId = brand.Brandid,
                BrandName = brand.Brandname,

            }).ToList();
            Log.Information("Ecommerce: ProductRepository: Brands: Completed");
            return await Task.FromResult(brands);
        }
        public async Task<List<ProductDM>> Products(String brandid)
        {
            Log.Information("Ecommerce: ProductRepository: Products: Started");
            var products = _CORECONTEXT.Products.Where(x => x.Brandid.ToString() == brandid).Select(product => new ProductDM()
            {
                ProductId = product.Productid,
                ProductName = product.Productname,
                Price = (decimal)product.Price

            }).ToList();
            Log.Information("Ecommerce: ProductRepository: Products: Completed");
            return await Task.FromResult(products);
        }
        #endregion
    }
}
