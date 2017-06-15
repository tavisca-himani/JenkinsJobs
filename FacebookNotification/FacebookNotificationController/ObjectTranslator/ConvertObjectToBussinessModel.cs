using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ObjectTranslator
{
    public class ConvertObjectToBussinessModel
    {
        public static Model.Notification ToDomain( DataContract.Notification notification)
        {
            return new Model.Notification
            {
                _id = Guid.NewGuid(),
                
                Message = notification.Message,
                Date = DateTime.Now

            };
        }
        public static Model.User ToCredentialsDomain(DataContract.User credentials)
        {
            return new Model.User
            {
                _id = Guid.NewGuid(),
            UserName = credentials.UserName,
                Password = credentials.Password

            };
        }
    }
}
