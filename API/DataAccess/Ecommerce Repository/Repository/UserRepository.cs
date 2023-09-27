using Ecommerce_Repository.DBContext.Admin;
using Ecommerce_Repository.IRepository;
using Ecommerce_Repository.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ecommerce_Repository.Repository
{
    public class UserRepository : IUserRepository

    {
        private readonly AdminContext _ADMINCONTEXT;
        public UserRepository(AdminContext adminContext)
        {
            _ADMINCONTEXT = adminContext;
        }
        public async Task<String> ValidateUser(LoginDM login)
        {
            var isAvailableUser = "Invalid";
            var userDetail = _ADMINCONTEXT.Users.FirstOrDefault(x => x.Email == login.UserName && x.PasswordHash == login.Password);
            if (userDetail != null)
            {
                isAvailableUser = "Valid";
            }
            return await Task.FromResult(isAvailableUser);
        }
    }
}
