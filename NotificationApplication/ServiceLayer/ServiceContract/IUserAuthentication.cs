using ServiceLayer.DataContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.ServiceContract
{
    public interface IUserAuthentication
    {
        bool AuthenticateUser(User user);
        bool ChangePassword(User user, string newPassword);
    }
}
