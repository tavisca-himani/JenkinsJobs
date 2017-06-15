using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BussinessLogic
{
   public interface IUserManager
    {
        Task<bool> GetUser(Model.User credentials);

        Task<bool> SubscribeUser(Model.User credentials);

        Task<List<Model.User>> GetAllUser();

    }
}
