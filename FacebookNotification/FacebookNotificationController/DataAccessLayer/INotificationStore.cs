using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public interface INotificationStore
    {
        Task<List<Notification>> GetAllNotificationAsync(string userName);

        Task<bool> InsertNotificationAsync(Notification notification);
        Task<int> GetUnreadMessageCountAsync(string userName);
    }
}
