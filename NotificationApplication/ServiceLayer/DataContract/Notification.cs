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
    public class Notification
    {
        [DataMember]
        [Required]
        public string Id { get; set; }
        [DataMember]
        [Required]
        public  string Message { get; set; }
        [DataMember]
        public  DateTime NotificationDate { get; set; }
        [DataMember]
        public  DateTime ExpirationDate { get; set; }
        [DataMember]
        public bool UseLocalTime { get; set; }
        
    }

}

