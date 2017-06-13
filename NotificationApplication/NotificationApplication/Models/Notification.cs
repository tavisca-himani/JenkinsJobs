using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace NotificationApplication.Models
{
    public class Notification
    {
        public static ObjectIDGenerator Id { get; set; }
        public static string Message { get; set; }
        public static DateTime NotificationDate { get; set; }
        public static DateTime ExpirationDate { get; set; }
        public static bool UseLocalTime { get; set; }
        public static bool ReadStatus { get; set; }
    }
}