using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using ServiceStack.Redis;

namespace DataAccessLayer
{
    public class RedisStorage : DecoratorClass
    {
        private RedisClient _client;
        public RedisStorage(INotificationStore storage) : base(storage)
        {
            _client = new RedisClient();
        }
        
        public override async Task<List<Notification>> GetAllNotificationAsync(string userName)
        {
            var result = _client.Get<List<Notification>>("notification");
            if (result == null)
            {
                List<Notification> list = await _storage.GetAllNotificationAsync(userName);
                _client.Set("notification", list);
                result = list;
            }
            return result;
        }

        public override Task<int> GetUnreadMessageCountAsync(string userName)
        {
            return _storage.GetUnreadMessageCountAsync(userName);
        }

        public override Task<bool> InsertNotificationAsync(Notification notification)
        {
            _client.FlushAll();
            return _storage.InsertNotificationAsync(notification);
        }
      
    }
}
