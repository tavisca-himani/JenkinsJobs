using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataContract;

namespace NotificationAdaptor
{
    public interface IUserHandler
    {
        Task<bool> GetUser(DataContract.User credentials);

        Task<bool> Subscriber(DataContract.User credentials);
        Task<List<User>> GetAllUser();
    }
}
