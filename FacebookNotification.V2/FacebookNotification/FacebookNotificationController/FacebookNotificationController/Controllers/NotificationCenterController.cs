using ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;

namespace FacebookNotificationController.Controllers
{
   
    [RoutePrefix("api")]
    public class NotificationCenterController : ApiController
    {
        private INotificationDispatcher _service;
        private IUserDispatcher _dispatcher;
        public NotificationCenterController(INotificationDispatcher service, IUserDispatcher dispatcher)
        {
            _service = service;
            _dispatcher = dispatcher;
        }
        // GET api/values
        [HttpGet]
        [Route("notification/get/{userName}")]
        public async Task<List<DataContract.Notification>> Get(string userName)
        {
           
            return await _service.GetAllNotification(userName) ;
        }
        [HttpGet]
        [Route("user/getAll")]
        public async Task<List<DataContract.User>> getAllUser()
        {
             var result =await _dispatcher.GetAllUser();
            return result;
        }
        [HttpGet]
        [Route("count/{userName}")]

        public async Task<int> getCount(string userName)
        {
            return await _service.GetCount(userName);
        }
        // POST api/values
        [HttpPost]
        [Route("notification/Add")]
        public async Task<bool> Post([FromBody]DataContract.Notification notification)
        {
            return await _service.SendNotification(notification);
        }
        [Route("login/AuthenticateUser")]
        [HttpPost]
        public async Task<bool> SearchUser([FromBody]DataContract.User credentials)
        {
            return await _dispatcher.GetUserDetails(credentials);
        }

        // POST: api/Login
        [Route("login/Subscriber")]
        [HttpPost]
        public async Task<bool> AddUser([FromBody]DataContract.User credentials)
        {
            return await _dispatcher.Subscriber(credentials);
        }

    }
}
