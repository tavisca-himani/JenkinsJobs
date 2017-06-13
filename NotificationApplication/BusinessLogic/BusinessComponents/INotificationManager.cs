
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLogic.BusinessComponents
{
    public interface INotificationManager
    {
        Task<List<Notification>> GetNotificationsAsync(string userEmail);
        Task<Notification> PushNotificationsAsync(Notification notification);
        Task<int> GetUnreadNotificationCount(string user);
    }
}
