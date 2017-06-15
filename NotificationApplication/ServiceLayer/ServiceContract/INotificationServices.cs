using ServiceLayer.DataContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.ServiceContract
{
    public interface INotificationServices
    {
        Task<List<Notification>> GetNotificationsAsync(string username);
        Task<Notification> PushNotificationsAsync(Notification notification);
        Task<int> GetUnreadNotificationCount(string  user);
    }
}
