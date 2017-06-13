using Newtonsoft.Json;
using ServiceLayer.DataContract;
using ServiceLayer.ServiceContract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace NotificationApplication.Controllers
{
    [RoutePrefix("api/Notifications")]
    public class ServicesController : ApiController
    {
        INotificationServices _notification;
        IUserAuthentication _authenticate;
        public ServicesController()
        {

        }
        public ServicesController(INotificationServices notification, IUserAuthentication authenticate)
        {
            _notification = notification;
            _authenticate = authenticate;
        }
        [HttpGet]
        [Route("get/{UserEmail}")]
        public Task<List<Notification>> GetNotificationFromDB(string UserEmail)
         {
            List<Notification> listofNotifications = new List<Notification>();

           var listOfNotifications =  _notification.GetNotificationsAsync(UserEmail);
            return listOfNotifications;
        }
        
        [HttpPost]
        [Route("postMsg")]
        public IHttpActionResult PutAsync([FromBody]Notification notify)
        {
            notify.Id = Guid.NewGuid().ToString();
            _notification.PushNotificationsAsync(notify);
            return Ok();
        }

        [HttpPost]
        [Route("authenticate")]
        public bool AuthenticateUsers([FromBody]User user)
        {
            if (!ModelState.IsValid)
                return false;
            var result = _authenticate.AuthenticateUser(user);

            return result;
        }
        [HttpPost]
        [Route("changePassword")]
        public bool ChangePassword([FromBody]User user, string newPassword)
        {
            if (!ModelState.IsValid)
                return false;
            var result = _authenticate.ChangePassword(user, newPassword);
            return result;
        }

        [HttpGet]
        [Route("unreadNotification/{username}")]
        public Task<int> GetUnreadNotificationCount(string username)
         {
            var result = _notification.GetUnreadNotificationCount(username);
            return result;
        }
        
    }
}
