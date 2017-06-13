using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Model
{
    public class Notification
    {
        public string Id { get; set; }
        public string Message { get; set; }
        public DateTime NotificationDate { get; set; }
        public DateTime ExpirationDate { get; set; }
        public bool UseLocalTime { get; set; }
        
    }
}
