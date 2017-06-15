using BusinessLogic.BusinessComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using DataAccess.DataAccessComponents;

namespace BusinessLogic.BusinessWorkflow
{
    public class UserAuthenticationManagementService : IUserAuthenticationManager
    {
        IUserAuthenticationCheck _checkAuthentication;
        public  UserAuthenticationManagementService(IUserAuthenticationCheck checkAuthentication)
        {
            _checkAuthentication = checkAuthentication;
        }
        public bool AuthenticateUser(User user)
        {
            var result =  _checkAuthentication.AuthenticateUser(user);
            return result;
        }

        public bool ChangePassword(User user , string newPassword)
        {
            var result = _checkAuthentication.ChangePassword(user, newPassword);
            return result;
        }
    }
}
