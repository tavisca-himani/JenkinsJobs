using System;
using System.Collections.Generic;
using DataContract;
using NotificationAdaptor;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public class NotificationDispatcher : INotificationDispatcher
    {
        private INotificationHandler _handler;

        public NotificationDispatcher(INotificationHandler handler)
        {
            _handler = handler;
        }


        public async Task<List<Notification>> GetAllNotification(string userName)
        {
            if(userName == null)
            {
                throw new Exception("UserName Cannot be Null");
            }
            return await _handler.GetNotification(userName);
        }

        public async Task<int> GetCount(string userName)
        {
            return await _handler.GetCountOfUnreadMessage(userName);
        }

        public async Task<bool> SendNotification(DataContract.Notification notification)
        {
            if (notification.Message == "")
            {
                throw new Exception("Message cannot be null");
            }
            
            
            return  await _handler.SendNotificationToHandler(notification);
        }
    }
}
