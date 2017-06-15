using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;
using MongoDB.Driver;

namespace DataAccessLayer
{
    public class UserDataRepository : IUser
    {
        private MongoClient _client;
        private IMongoCollection<User> _collection;

        public UserDataRepository()
        {
            _client = new MongoClient();
            _collection = _client.GetDatabase("FacebookNotificationSystem").GetCollection<User>("UserDetails");
        }

        public async Task<User> GetUserDetailsAsync(string userName)
        {
            try
            {
               var result = await _collection.FindAsync(x => x.UserName == userName);
                return result.First();
            }
            catch (Exception) {
                throw new Exception("User Does Not Exits");
            }
        }

        public async Task<bool> AddUserAsync(User credentials)
        {
            var userNameExists =  _collection.Find(x => x.UserName == credentials.UserName).Count();
            if(userNameExists == 0)
            {
               await _collection.InsertOneAsync(credentials);
                return true;
            }
            return false;
        }

        public async  Task<List<User>> GetAllUser()
        {
            return await _collection.Find(x => x._id != null).ToListAsync<User>();
        }
    }
}
