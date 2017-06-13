using System;
using System.Threading.Tasks;
using DataAccess.DataAccessComponents;
using BusinessLogic.BusinessComponents;
using System.Collections.Generic;
using Model;

namespace BusinessLogic.BusinessWorkflow
{
    public class NotificationManager : INotificationManager
    {
        public IAppUser _user;
        public NotificationManager(IAppUser user)
        {
            _user = user;
        }
        public async Task<List<Notification>> GetNotificationsAsync(string userEmail)
        {
            var listOfNotifications = await _user.GetNotificationFromDB( userEmail);
            return (listOfNotifications == null) ? null : listOfNotifications ;
        }

        public async Task<Notification> PushNotificationsAsync(Notification notification)
        {
            var result =  await _user.SaveNotificationToDB(notification);
            return result;
        }
        public async Task<int> GetUnreadNotificationCount(string userName)
        {
            var count = await _user.GetUnreadNotificationCount(userName);
            return count;
        }
    }
}
