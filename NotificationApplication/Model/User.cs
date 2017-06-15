using MongoDB.Bson;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class User
    {
        public ObjectId _id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int UnreadNotifications { get; set; }

        public void Validate()
        {
          
            if (string.IsNullOrWhiteSpace(this.Email))
                throw new Exception("Email cannot be null or empty.");
            if (Password.Count() > 8)
                throw new Exception("Password cannot be  greater than 8 characters ");
            if(string.IsNullOrEmpty(this.Password) )
                throw new Exception("Password cannot be null or empty !");
        }
    }
}
