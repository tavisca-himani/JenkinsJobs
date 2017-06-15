using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.DataContract
{
    [DataContract]
    public class User
    {
        [BsonId]
        public ObjectId _id { get; set; }

        [DataMember]

        public string Email { get; set; }
        [DataMember]

        public string Password { get; set; }

        [DataMember]
        public int UnreadNotifications { get; set; }


    }

}
