﻿#region namespaces
using CoreComponents.Constants;
using CoreComponents.EncryptDecrypt;
using Ecommerce_Repository.DBContext.Admin;
using Ecommerce_Repository.IRepository;
using Ecommerce_Repository.Models;
using Serilog;
#endregion

namespace Ecommerce_Repository.Repository
{
    public class UserRepository : IUserRepository

    {
        #region readonly fields
        private readonly AdminContext _ADMINCONTEXT;
        #endregion
        #region constructor
        public UserRepository(AdminContext adminContext)
        {
            _ADMINCONTEXT = adminContext;
        }
        #endregion
        #region methods
        public async Task<String> ValidateUser(LoginDM login)
        {
            Log.Information("Ecommerce: UserRepository: ValidateUser: Started");
            var isAvailableUser = Constants.Invalid;
            var passwordHash = EncryptDecrypt.EncryptPassword(login.Password);
            var userDetail = _ADMINCONTEXT.Customers.FirstOrDefault(x => x.Email == login.UserName && x.Passwordhash == passwordHash);
            if (userDetail != null)
            {
                isAvailableUser = Constants.Valid;
            }
            Log.Information("Ecommerce: UserRepository: ValidateUser: Completed");

            return await Task.FromResult(isAvailableUser);
        }
        public async Task<String> SignUp(NewUserDM newUserDM)
        {
            Log.Information("Ecommerce: UserRepository: SignUp: Started");

            var status = String.Empty;
            var isAvailableUser = _ADMINCONTEXT.Customers.FirstOrDefault(x => x.Email == newUserDM.Email);
            if (isAvailableUser != null)
            {
                Log.Information("Ecommerce: UserRepository: SignUp: User Already Exists");
                status = Constants.UserExists;
            }
            else
            {
                Log.Information("Ecommerce: UserRepository: SignUp: New User Add Started");

                var user = new Customer()
                {
                    Firstname = newUserDM.FirstName,
                    Lastname = newUserDM.LastName,
                    Email = newUserDM.Email,
                    Passwordhash = EncryptDecrypt.EncryptPassword(newUserDM.Password)

                };
                using (var transaction = _ADMINCONTEXT.Database.BeginTransaction())
                {
                    try
                    {
                        _ADMINCONTEXT.Customers.Add(user);
                        _ADMINCONTEXT.SaveChanges();
                        transaction.Commit();
                        status = Constants.AddedSuccessfully;
                        Log.Information("User Added Successfully");
                    }
                    catch (Exception ex)
                    {
                        Log.Error("Transaction Failed: " + ex.Message + " Stack Trace: " + ex.StackTrace);
                        transaction.Rollback();
                        status = Constants.Failed;

                    }
                }
                Log.Information("Ecommerce: UserRepository: SignUp: New User Add Completed with Status:" + status);

            }
            Log.Information("Ecommerce: UserRepository: SignUp: Completed");
            return await Task.FromResult(status);
        }
        #endregion
    }
}
