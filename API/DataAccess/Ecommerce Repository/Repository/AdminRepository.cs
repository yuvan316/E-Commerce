using CoreComponents.Constants;
using Ecommerce_Repository.DBContext.Admin;
using Ecommerce_Repository.IRepository;
using Ecommerce_Repository.Models;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_Repository.Repository
{
    public class AdminRepository : IAdminRepository
    {
        #region readonly fields
        private readonly AdminContext _ADMINCONTEXT;
        #endregion
        #region constructor
        public AdminRepository(AdminContext adminContext)
        {
            _ADMINCONTEXT = adminContext;
        }
        #endregion
        #region methods
        public async Task<String> ValidateUser(LoginDM login)
        {
            Log.Information("Ecommerce: AdminRepository: ValidateUser: Started");
            var isAvailableUser = Constants.Invalid;
            var userDetail = _ADMINCONTEXT.AdminUsers.FirstOrDefault(x => x.Email == login.UserName);
            if (userDetail == null || !BCrypt.Net.BCrypt.Verify(login.Password, userDetail.PasswordHash))
            {
                Log.Information("Ecommerce: AdminRepository: ValidateUser: InvalidUser");
            }
            else
            {
                isAvailableUser = Constants.Valid;
            }
            Log.Information("Ecommerce: AdminRepository: ValidateUser: Completed");

            return await Task.FromResult(isAvailableUser);
        }
        public async Task<String> SignUp(NewUserDM newUserDM)
        {
            Log.Information("Ecommerce: AdminRepository: SignUp: Started");

            var status = String.Empty;
            var isAvailableUser = _ADMINCONTEXT.AdminUsers.FirstOrDefault(x => x.Email == newUserDM.Email);
            if (isAvailableUser != null)
            {
                Log.Information("Ecommerce: AdminRepository: SignUp: User Already Exists");
                status = Constants.UserExists;
            }
            else
            {
                Log.Information("Ecommerce: AdminRepository: SignUp: New User Add Started");

                var user = new AdminUser()
                {
                    FirstName = newUserDM.FirstName,
                    LastName = newUserDM.LastName,
                    Email = newUserDM.Email,
                    PasswordHash = BCrypt.Net.BCrypt.HashPassword(newUserDM.Password)

                };
                using (var transaction = _ADMINCONTEXT.Database.BeginTransaction())
                {
                    try
                    {
                        _ADMINCONTEXT.AdminUsers.Add(user);
                        _ADMINCONTEXT.SaveChanges();
                        transaction.Commit();
                        status = Constants.AddedSuccessfully;
                        Log.Information("Ecommerce: AdminRepository: SignUp: User Added Successfully");
                    }
                    catch (Exception ex)
                    {
                        Log.Error("Ecommerce: AdminRepository: SignUp: Transaction Failed: " + ex.Message + " Stack Trace: " + ex.StackTrace);
                        transaction.Rollback();
                        status = Constants.Failed;

                    }
                }
                Log.Information("Ecommerce: AdminRepository: SignUp: New User Add Completed with Status:" + status);

            }
            Log.Information("Ecommerce: AdminRepository: SignUp: Completed");
            return await Task.FromResult(status);
        }
        #endregion
    }
}
