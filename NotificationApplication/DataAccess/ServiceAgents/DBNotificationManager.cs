using DataAccess.DataAccessComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MongoDB.Driver;
using Model;

namespace DataAccess.ServiceAgents
{
    public class DBNotificationManager : IAppUser
    {
        public MongoClient client;
        public IMongoCollection<Notification> notificationCollection;
        public IMongoCollection<User> userCollection;
       public DBNotificationManager()
        {
            client = new MongoClient();
            notificationCollection = client.GetDatabase("UserAndNotificationStorage").GetCollection<Notification>("NotificationCollection");
            userCollection = client.GetDatabase("UserAndNotificationStorage").GetCollection<User>("UserDataCollection");
        }
        public void UpdateNotificationCount()
        {
            var filter = Builders<User>.Filter.Where(x => x.Email != null);
            var update = Builders<User>.Update.Inc("UnreadNotifications", 1);
            var upsert = new UpdateOptions { IsUpsert = true };
             userCollection.UpdateMany(filter, update, upsert);
           
        }

        public void ResetNotificationCount(string userEmail)
        {
            var filter = Builders<User>.Filter.Where(x => x.Email == userEmail);
            var update = Builders<User>.Update.Set("UnreadNotifications", 0);
            userCollection.FindOneAndUpdateAsync(filter, update);

        }


        public async Task<Notification> SaveNotificationToDB(Notification notification)
        {
            if(notification == null)
            return null;
            UpdateNotificationCount();
             await notificationCollection.InsertOneAsync(notification);
            return notification;
        }

       

        public async Task<List<Notification>> GetNotificationFromDB(string userEmail)
        {
            if (userEmail == null)
                throw new ArgumentNullException();

            List<Notification> listOfNotifications = await notificationCollection.Find(x => true).ToListAsync();
            listOfNotifications.Reverse();
            ResetNotificationCount(userEmail);
            return listOfNotifications;
        }

        public async Task<int> GetUnreadNotificationCount(string  userName)
        {
            var userFound =  await userCollection.Find(x => x.Email.Equals(userName)).SingleAsync();
            return (userFound != null) ? userFound.UnreadNotifications : 0;
        }
    }
}
