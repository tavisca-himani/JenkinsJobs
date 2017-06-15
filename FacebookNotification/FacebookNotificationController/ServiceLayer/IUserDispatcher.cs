using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataContract;

namespace ServiceLayer
{
    public interface IUserDispatcher
    {
        Task<bool> GetUserDetails(DataContract.User credentials);

        Task<bool> Subscriber(DataContract.User credentials);
        Task<List<User>> GetAllUser();
    }
}
