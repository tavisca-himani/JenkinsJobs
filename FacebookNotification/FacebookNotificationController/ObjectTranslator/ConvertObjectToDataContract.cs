using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectTranslator
{
   public class ConvertObjectToDataContract
    {
        public static DataContract.Notification ToModel(Model.Notification notification)
        {
            return new DataContract.Notification
            { 
                Message = notification.Message
            };
        }

        public static DataContract.User ToCredentialsModel(Model.User credentials)
        {
            return new DataContract.User
            {
                UserName = credentials.UserName,
                Password = credentials.Password
            };
        }
    }
}