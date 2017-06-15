using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DataAccessLayer
{
    public interface IUser
    {
        Task<Model.User> GetUserDetailsAsync(string userName);

        Task<bool> AddUserAsync(Model.User credentials);
        Task<List<User>> GetAllUser();
    }
}
