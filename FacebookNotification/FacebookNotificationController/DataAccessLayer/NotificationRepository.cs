using Model;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer
{
    public class NotificationRepository : INotificationStore
    {
        private MongoClient _client;
        private IMongoCollection<Notification> _collection;
        private IMongoCollection<User> _userCollection;

        public NotificationRepository()
        {
            _client = new MongoClient();
            _collection = _client.GetDatabase("FacebookNotificationSystem").GetCollection<Notification>("FacebookNotificationData");
            _userCollection = _client.GetDatabase("FacebookNotificationSystem").GetCollection<User>("UserDetails");
        }

        public async Task<List<Notification>> GetAllNotificationAsync(string userName)
        {
            ResetUnreadMessageCount(userName);
            return  await _collection.Find(x => x.Message != null).Sort(Builders<Notification>.Sort.Descending("Date")).ToListAsync<Notification>();
        }

        public async Task<bool> InsertNotificationAsync(Notification notification)
        {

           
                await _collection.InsertOneAsync(notification);
                await UpdateUnreadMessageCount();
                return true;
           
            
        }

        public async Task UpdateUnreadMessageCount()
        {
            
            
               var  condition = Builders<User>.Update.Inc("unreadMessageCount", 1);
                var update = new UpdateOptions { IsUpsert = true };
                  await _userCollection.UpdateManyAsync<User>(x => x._id != null, condition, update);
            

        }

        public bool ResetUnreadMessageCount(string userName)
        {
            var condition = Builders<User>.Update.Set("unreadMessageCount", 0);

            var update = new UpdateOptions { IsUpsert = true };
            var returnValue = _userCollection.UpdateMany<User>(x => x.UserName == userName, condition, update);
            return (returnValue.ModifiedCount > 0) ? true : false;
        }

        public async Task<int> GetUnreadMessageCountAsync(string userName)
        {
            var result= await _userCollection.FindAsync<User>(x => x.UserName == userName  );
            return result.First().unreadMessageCount;
        }
    }
}