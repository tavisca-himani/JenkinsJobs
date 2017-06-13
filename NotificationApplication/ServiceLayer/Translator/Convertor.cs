
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Translator
{
    public static class Convertor
    {
        public static DataContract.Notification ToDataContract(this Notification notification)
        {
            return new DataContract.Notification
            {
                Message = notification.Message,
                Id = notification.Id,
                NotificationDate = notification.NotificationDate,
                UseLocalTime = notification.UseLocalTime
                

            };
        }

        public static Notification ToDomainModel(this DataContract.Notification notification)
        {
            return (notification == null) ? null : new Notification
            {
                Message = notification.Message,
                Id = notification.Id,
                NotificationDate = notification.NotificationDate,
                UseLocalTime = notification.UseLocalTime
               

            };


        }

        public static User ToModel(this DataContract.User user)
        {
            return new User
            {
                _id = user._id,
                Email = user.Email,
                Password = user.Password
                

            };
        }

        public static DataContract.User ToDataContract(this User user)
        {
            return new DataContract.User
            {
                _id = user._id,
                Email = user.Email,
                Password = user.Password

            };
        }

    }
}
