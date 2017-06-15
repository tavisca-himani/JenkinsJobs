using BussinessLogic;
using DataContract;
using Moq;
using NotificationAdaptor;
using ServiceLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;
namespace TranslatorTest
{
    public class ServiceLayerTestCases
    {
       
        [Fact]
        public void Check_For_Request_To_Send_To_NotificationHandler()
        #region
        {
            DataContract.Notification notification = new DataContract.Notification {
               
                Message = "This is mocking"
            };
            Mock<INotificationHandler> mockNotificationAdaptorObject = new Mock<INotificationHandler>();
            mockNotificationAdaptorObject.Setup(request => request.SendNotificationToHandler(notification)).Returns(Task.FromResult(true));

            NotificationDispatcher notificationRequest = new NotificationDispatcher(mockNotificationAdaptorObject.Object);

            var result =notificationRequest.SendNotification(notification);

            Task.Equals(true, result);
        }
        #endregion
       
        [Fact]
        public void Check_For_GetResponse_From_Service_Layer_type()
        #region
        {
        Mock<INotificationHandler> mockNotificationHandler = new Mock<INotificationHandler>();
            mockNotificationHandler.Setup(handler => handler.GetNotification(It.IsAny<string>())).Returns(Task.FromResult(new List<DataContract.Notification>()));

            NotificationDispatcher dispatcher = new NotificationDispatcher(mockNotificationHandler.Object);
            var result = dispatcher.GetAllNotification("chaitali");
            

        }
        #endregion
        
        [Fact]
        public void Check_For_GetCountOfUnread_Message()
        #region
        {
            Mock<INotificationManager> mockNotificationHandler = new Mock<INotificationManager>();
            mockNotificationHandler.Setup(handler => handler.GetUnreadNotificationCountFromDataBase(It.IsAny<string>())).Returns(Task.FromResult(2));

            NotificationHandler notificationHandler = new NotificationHandler(mockNotificationHandler.Object);
            var result =notificationHandler.GetCountOfUnreadMessage("chaitali");

            Task.Equals(2, result);
        }
        #endregion
        [Fact]
        public void Check_For_GetCountOfUnread_Message_when_read()
        #region
        {
            Mock<INotificationManager> mockNotificationHandler = new Mock<INotificationManager>();
            mockNotificationHandler.Setup(handler => handler.GetUnreadNotificationCountFromDataBase(It.IsAny<string>())).Returns(Task.FromResult(0));

            NotificationHandler notificationHandler = new NotificationHandler(mockNotificationHandler.Object);
            var result = notificationHandler.GetCountOfUnreadMessage("chaitali");

            Task.Equals(0, result);
        }
        #endregion
        [Fact]
        public async void Check_For_SendNotification_If_Message_Is_Empty()
        #region
        {
            DataContract.Notification notification = new DataContract.Notification
            {

                Message = ""
            };
            Mock<INotificationHandler> mockNotificationAdaptorObject = new Mock<INotificationHandler>();
            mockNotificationAdaptorObject.Setup(request => request.SendNotificationToHandler(notification)).Returns(Task.FromResult(true));

            NotificationDispatcher notificationRequest = new NotificationDispatcher(mockNotificationAdaptorObject.Object);
            
           await Assert.ThrowsAsync<Exception>(async () => await notificationRequest.SendNotification(notification));
        }
        #endregion
        
        [Fact]
        public async void Check_For_GetAllNotification_If_UserName_Is_Null()

        #region
        {
            Mock<INotificationHandler> mockNotificationHandler = new Mock<INotificationHandler>();
            mockNotificationHandler.Setup(handler => handler.GetNotification(It.IsAny<string>())).Returns(Task.FromResult(new List<DataContract.Notification>()));

            NotificationDispatcher dispatcher = new NotificationDispatcher(mockNotificationHandler.Object);
           await  Assert.ThrowsAsync<Exception>(async ()=> await dispatcher.GetAllNotification(null)); 
        }
        #endregion
       
        [Fact]
        public void Check_If_User_Password_Is_Invalid()
        #region
        {
            User user = new User
            {
                UserName = "chaitali",
                Password= "1234567"
            };
            Mock<IUserHandler> mockUserDispatcherLayer = new Mock<IUserHandler>();
            mockUserDispatcherLayer.Setup(dispatcher => dispatcher.GetUser(It.IsAny<User>())).Returns(Task.FromResult(false));

            UserDispatcher userDispatcher = new UserDispatcher(mockUserDispatcherLayer.Object);
           var result =userDispatcher.GetUserDetails(user);
            Task.Equals(false, result);
        }
        #endregion

        
        [Fact]
        public void Check_If_User_Is_Valid()
        #region
        {
            User user = new User
            {
                UserName = "chaitali",
                Password = "1234"
            };
            Mock<IUserHandler> mockUserDispatcherLayer = new Mock<IUserHandler>();
            mockUserDispatcherLayer.Setup(dispatcher => dispatcher.GetUser(It.IsAny<User>())).Returns(Task.FromResult(true));

            UserDispatcher userDispatcher = new UserDispatcher(mockUserDispatcherLayer.Object);
            var result = userDispatcher.GetUserDetails(user);
            Task.Equals(true, result);
        }
        #endregion

        
        [Fact]
        public void Check_If_User_Subscribes_Properly()
        #region
        {
            User user = new User
            {
                UserName = "Chaitu",
                Password = "1234"
            };
            Mock<IUserHandler> mockUserDispatcherLayer = new Mock<IUserHandler>();
            mockUserDispatcherLayer.Setup(dispatcher => dispatcher.Subscriber(It.IsAny<User>())).Returns(Task.FromResult(true));

            UserDispatcher userDispatcher = new UserDispatcher(mockUserDispatcherLayer.Object);
            var result = userDispatcher.Subscriber(user);
            Task.Equals(true, result);
        }
        #endregion

       
        [Fact]
        public async void Check_If_User_Subscribes_With_No_User_Name()
        #region
        {
            User user = new User
            {
                UserName = null,
                Password = "1234"
            };

            Mock<IUserHandler> mockUserDispatcherLayer = new Mock<IUserHandler>();
            mockUserDispatcherLayer.Setup(dispatcher => dispatcher.Subscriber(It.IsAny<User>())).Returns(Task.FromResult(false));

            UserDispatcher userDispatcher = new UserDispatcher(mockUserDispatcherLayer.Object);
           
           await Assert.ThrowsAsync<Exception>(async () => await userDispatcher.Subscriber(user));
        }
        #endregion

       
        [Fact]
        public async void Check_If_User_Subscribes_With_No_Password()
        #region
        {
            User user = new User
            {
                UserName = "chaitu",
                Password = null
            };

            Mock<IUserHandler> mockUserDispatcherLayer = new Mock<IUserHandler>();
            mockUserDispatcherLayer.Setup(dispatcher => dispatcher.Subscriber(It.IsAny<User>())).Returns(Task.FromResult(false));

            UserDispatcher userDispatcher = new UserDispatcher(mockUserDispatcherLayer.Object);

            await Assert.ThrowsAsync<Exception>(async () => await userDispatcher.Subscriber(user));
        }
        #endregion

        [Fact]
        public async void Check_If_UserName_If_Null()
        #region
        {
            User user = new User
            {
                UserName = null,
                Password = "123456"
            };

            Mock<IUserHandler> mockUserDispatcherLayer = new Mock<IUserHandler>();
            mockUserDispatcherLayer.Setup(dispatcher => dispatcher.GetUser(It.IsAny<User>())).Returns(Task.FromResult(false));

            UserDispatcher userDispatcher = new UserDispatcher(mockUserDispatcherLayer.Object);

            await Assert.ThrowsAsync<Exception>(async () => await userDispatcher.GetUserDetails(user));
        }
        #endregion

        [Fact]
        public async void Check_If_Password_If_Null()
        #region
        {
            User user = new User
            {
                UserName = "chaitali",
                Password = null
            };

            Mock<IUserHandler> mockUserDispatcherLayer = new Mock<IUserHandler>();
            mockUserDispatcherLayer.Setup(dispatcher => dispatcher.GetUser(It.IsAny<User>())).Returns(Task.FromResult(false));

            UserDispatcher userDispatcher = new UserDispatcher(mockUserDispatcherLayer.Object);

            await Assert.ThrowsAsync<Exception>(async () => await userDispatcher.GetUserDetails(user));
        }
        #endregion
    }
}
