
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataAccess.DataAccessComponents
{
    public interface IAppUser
    {
        void UpdateNotificationCount();
        void ResetNotificationCount(string Email);
       Task<Notification> SaveNotificationToDB(Notification notification);
        Task<List<Notification>> GetNotificationFromDB(string userEmail);
        Task<int> GetUnreadNotificationCount(string userName);


    }
}
