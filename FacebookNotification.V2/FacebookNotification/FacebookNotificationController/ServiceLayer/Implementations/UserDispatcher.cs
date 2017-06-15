using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataContract;
using NotificationAdaptor;

namespace ServiceLayer
{
   public class UserDispatcher : IUserDispatcher

    {
        private IUserHandler _userHandler;

        public UserDispatcher(IUserHandler userHandler)
        {
            _userHandler = userHandler;
        }
        public async Task<bool> GetUserDetails(User credentials)
        {
            Check_If_User_Has_User_Name_And_Password(credentials);
            return await _userHandler.GetUser(credentials);
        }

        public async Task<bool> Subscriber(User credentials)

        {
            Check_If_User_Has_User_Name_And_Password(credentials);
            return await _userHandler.Subscriber(credentials);
        }

        public void Check_If_User_Has_User_Name_And_Password(User credentials)
        {
            if (credentials.UserName == null)
            {
                throw new Exception("UserName Cannot Be Empty");
            }
            if (credentials.Password == null)
            {
                throw new Exception("Pasword Cannot Be Empty");
            }
        }

        public async Task<List<User>> GetAllUser()
        {
          return  await _userHandler.GetAllUser();
        }
    }
}
