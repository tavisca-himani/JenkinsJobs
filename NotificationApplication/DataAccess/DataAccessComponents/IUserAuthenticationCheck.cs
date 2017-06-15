using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.DataAccessComponents
{
    public interface IUserAuthenticationCheck
    {
       bool AuthenticateUser(User user);
        bool ChangePassword(User user, string newPassword);
    }
}
