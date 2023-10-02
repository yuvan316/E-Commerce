#region namespaces
using Ecommerce_BL.BusinessDomain.Models;
using Ecommerce_BL.Interface;
using Ecommerce_Repository.IRepository;
using Ecommerce_Repository.Models;
using Mapster;
using Serilog;
#endregion

namespace Ecommerce_BL.BusinessDomain
{
    public class AdminBL : IAdminBL
    {
        #region readonly fields
        private readonly IAdminRepository _ADMINREPOSITORY;
        #endregion

        #region constructor
        public AdminBL(IAdminRepository adminRepository)
        {
            _ADMINREPOSITORY = adminRepository;
        }
        #endregion

        #region methods
        public async Task<String> SignUp(NewUserBM newUserBM)
        {
            Log.Information("Ecommerce: AdminBL: SignUp: Started");
            var newUserDM = newUserBM.Adapt<NewUserDM>();
            var status = await _ADMINREPOSITORY.SignUp(newUserDM);
            Log.Information("Ecommerce: AdminBL: SignUp: Completed");
            return await Task.FromResult(status);
        }
        #endregion
    }
}
