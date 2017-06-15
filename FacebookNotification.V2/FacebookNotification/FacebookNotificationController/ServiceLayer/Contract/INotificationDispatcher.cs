using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer
{
    public interface INotificationDispatcher
    {
      
        Task<List<DataContract.Notification>> GetAllNotification(string userName);

        Task<bool> SendNotification(DataContract.Notification notification);
        Task<int> GetCount(string userName);
    }
}
