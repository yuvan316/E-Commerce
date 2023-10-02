#region namespaces
using CoreComponents.Constants;
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
            //db context invoke
            var userDetail = _ADMINCONTEXT.Customers.FirstOrDefault(x => x.Email == login.UserName);
            if (userDetail == null || !BCrypt.Net.BCrypt.Verify(login.Password, userDetail.Passwordhash))
            {
                Log.Information("Ecommerce: UserRepository: ValidateUser: InvalidUser");
            }
            else
            {
                isAvailableUser = Constants.Valid;
            }
            return await Task.FromResult(isAvailableUser);
        }
        public async Task<String> SignUp(NewUserDM newUserDM)
        {
            Log.Information("Ecommerce: UserRepository: SignUp: Started");

            var status = String.Empty;
            //db context invoke
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
                    Passwordhash = BCrypt.Net.BCrypt.HashPassword(newUserDM.Password)

                };
                using (var transaction = _ADMINCONTEXT.Database.BeginTransaction())
                {//save data to db
                    try
                    {
                        _ADMINCONTEXT.Customers.Add(user);
                        _ADMINCONTEXT.SaveChanges();
                        transaction.Commit();
                        status = Constants.AddedSuccessfully;
                        Log.Information("Ecommerce: UserRepository: SignUp: User Added Successfully");
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
        public async Task<String> SetCustomerAddress(CustomerAddressDM customerAddressDM)
        {
            Log.Information("Ecommerce: UserRepository: SetCustomerAddress: Started");
            var status = String.Empty;
            var customerAddress = new Address()
            {
                Houseno = customerAddressDM.HouseNo,
                Streetorarea = customerAddressDM.StreetOrArea,
                City = customerAddressDM.City,
                Country = customerAddressDM.Country,
                Pincode = (decimal?)customerAddressDM.PinCode,
                Landmark = customerAddressDM.Landmark ?? String.Empty,
                Customerid = Guid.Parse(customerAddressDM.CustomerId)
            };

            using (var transaction = _ADMINCONTEXT.Database.BeginTransaction())
            {//save data to db
                try
                {
                    _ADMINCONTEXT.Addresses.Add(customerAddress);
                    _ADMINCONTEXT.SaveChanges();
                    transaction.Commit();
                    Log.Information("Ecommerce: UserRepository: SetCustomerAddress: Added Successfully");
                    status = Constants.AddedSuccessfully;
                }
                catch (Exception ex)
                {
                    Log.Information("Ecommerce: UserRepository: SetCustomerAddress: Failed: Message:" + ex.Message + "Stack Trace:" + ex.StackTrace);
                    status = Constants.Failed;
                    transaction.Rollback();
                }
            }
            Log.Information("Ecommerce: UserRepository: SetCustomerAddress: Completed");
            return await Task.FromResult(status);
        }
        #endregion
    }
}
