using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NotificationAdaptor
{
   public interface INotificationHandler
    {
        Task<bool> SendNotificationToHandler(DataContract.Notification notification);

        Task<List<DataContract.Notification>> GetNotification(string userName);
        Task<int> GetCountOfUnreadMessage(string userName);
    }
}
