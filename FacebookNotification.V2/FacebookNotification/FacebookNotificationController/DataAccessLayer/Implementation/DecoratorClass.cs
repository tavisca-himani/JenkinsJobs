using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DataAccessLayer
{
    public abstract class DecoratorClass : INotificationStore
    {
        protected INotificationStore _storage { set; get; }
        public DecoratorClass(INotificationStore storage)
        {
            _storage = storage;
        }
        public abstract Task<List<Notification>> GetAllNotificationAsync(string userName);


        public abstract Task<int> GetUnreadMessageCountAsync(string userName);


        public abstract Task<bool> InsertNotificationAsync(Notification notification);
        
    }
}
