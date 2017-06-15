using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DataAccessLayer;

namespace BussinessLogic
{
    public class UserManager : IUserManager
    {
        private IUser _user;

        public UserManager(IUser user)
        {
            _user = user;
        }

        public async Task<List<User>> GetAllUser()
        {
            return await _user.GetAllUser();
        }

        public async Task<bool> GetUser(User credentials)
        {
            var result =await  _user.GetUserDetailsAsync(credentials.UserName);
            if(result.Password == credentials.Password)
            {
                return true;
            }
            return false;

        }

        public async Task<bool> SubscribeUser(User credentials)
        {
            return await _user.AddUserAsync(credentials);
        }
    }
}
