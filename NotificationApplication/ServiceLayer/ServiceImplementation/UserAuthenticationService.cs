using ServiceLayer.ServiceContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLayer.DataContract;
using BusinessLogic.BusinessComponents;
using ServiceLayer.Translator;

namespace ServiceLayer.ServiceImplementation
{
    public class UserAuthenticationService : IUserAuthentication
    {
        IUserAuthenticationManager _manager;
        public UserAuthenticationService(IUserAuthenticationManager manager)
        {
            _manager = manager;
        }
        public  bool AuthenticateUser(User user)
        {
            var result =  _manager.AuthenticateUser(user.ToModel());
            return result;
        }

        public bool ChangePassword(User user, string newPassword)
        {
            var result = _manager.ChangePassword(user.ToModel(), newPassword);
            return result;
        }
    }
}
