using DataAccess.DataAccessComponents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using MongoDB.Driver;

namespace DataAccess.ServiceAgents
{
    public class DBUserAuthenticationServices : IUserAuthenticationCheck
    {
        public MongoClient client;
        public IMongoCollection<User> userCollection;
        public DBUserAuthenticationServices()
        {
            client = new MongoClient();
            userCollection = client.GetDatabase("UserAndNotificationStorage").GetCollection<User>("UserDataCollection");

        }
        public bool AuthenticateUser(User user)
        {

            var exists = userCollection.Find(y => y.Email.Equals(user.Email) && y.Password.Equals(user.Password)).Count();
            
           
            return (exists > 0) ? true : false;
            
        }

        public bool ChangePassword(User user, string newPassword)
        {
            var filter = Builders<User>.Filter.Where(x => x.Email == user.Email);
            var update = Builders<User>.Update.Set("Password", newPassword);
            userCollection.FindOneAndUpdateAsync(filter, update);
            return true;
        }
    }
}
