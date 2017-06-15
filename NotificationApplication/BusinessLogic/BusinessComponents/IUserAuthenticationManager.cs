using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.BusinessComponents
{
    public interface IUserAuthenticationManager
    {
        bool AuthenticateUser(User user);
       bool ChangePassword(User user, string newPassword);
    }
}
