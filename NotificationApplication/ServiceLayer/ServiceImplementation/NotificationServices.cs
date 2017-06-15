using ServiceLayer.ServiceContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ServiceLayer.DataContract;
using BusinessLogic.BusinessComponents;
using ServiceLayer.Translator;

namespace ServiceLayer.ServiceImplementation
{
    public class NotificationServices : INotificationServices
    {
        INotificationManager _manager;
        public NotificationServices(INotificationManager manager)
        {
            _manager = manager;
        }

        public async Task<List<Notification>> GetNotificationsAsync(string UserEmail)
        {
            
            var listofDataContractNotifications = new List<Notification>();

            var listOfNotifications = await _manager.GetNotificationsAsync(UserEmail);

            
            foreach(var notifications in listOfNotifications)
            {
                listofDataContractNotifications.Add(notifications.ToDataContract());
            }

            return (listOfNotifications == null) ? null : listofDataContractNotifications;
               
        }

        public async Task<Notification> PushNotificationsAsync(Notification notification)
        {
            
            var result = await _manager.PushNotificationsAsync(notification.ToDomainModel());
            return result.ToDataContract();
        }

        public async Task<int> GetUnreadNotificationCount(String userName)
        {
            var count = await _manager.GetUnreadNotificationCount(userName);
            return count;
        }
    }
}
