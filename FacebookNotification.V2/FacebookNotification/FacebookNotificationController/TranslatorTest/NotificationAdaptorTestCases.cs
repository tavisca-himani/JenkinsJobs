using BussinessLogic;
using Moq;
using NotificationAdaptor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TranslatorTest
{
    public class NotificationAdaptorTestCases
    {

        [Fact]
        public void Check_For_NotificationAdaptor_To_Send_Data_To_Handler()
        #region
        {
            DataContract.Notification notification = new DataContract.Notification
            {
               
                Message = "Testing NotificationAdaptor Send data handler"

            };
            Mock<INotificationManager> mockNotificationhandlerObject = new Mock<INotificationManager>();
            mockNotificationhandlerObject.Setup(handler => handler.InsertNotificationToDatabase(It.IsAny<Model.Notification>())).Returns(Task.FromResult(true));

            NotificationHandler notificationAdaptorRepository = new NotificationHandler(mockNotificationhandlerObject.Object);
            var result = notificationAdaptorRepository.SendNotificationToHandler(notification);

            Task.Equals(true, result);
        }
        #endregion

        [Fact]
        public void Check_For_Get_Recent_Data_From_handler()
        #region
        {
            List<DataContract.Notification> list = new List<DataContract.Notification> {
                new DataContract.Notification {Message ="This is the testing list" },
                new DataContract.Notification {  Message = "This is the testing list for demo" },
                new DataContract.Notification { Message = "This is the testing list for checking the content" } };

            Mock<INotificationManager> mockNotificationhandlerObject = new Mock<INotificationManager>();
            mockNotificationhandlerObject.Setup(handler => handler.GetNotificationFromDatabase(It.IsAny<string>())).Returns(Task.FromResult(new List<Model.Notification> {
                new Model.Notification { Message = "This is the testing list",Date = DateTime.Now },
                new Model.Notification {  Message = "This is the testing list for demo", Date= DateTime.Now},
                new Model.Notification {  Message = "This is the testing list for checking the content", Date= DateTime.Now} }));

            NotificationHandler notificationAdaptorRepository = new NotificationHandler(mockNotificationhandlerObject.Object);

            var result = notificationAdaptorRepository.GetNotification("chaitali");

            Task.Equals(list,result);

        }
        #endregion
        [Fact]
        public void Check_For_Get_All_Notification_From_Handler()
        #region

        {
            Mock<INotificationManager> mockNotificationHandlerObject = new Mock<INotificationManager>();
            mockNotificationHandlerObject.Setup(handler => handler.GetNotificationFromDatabase(It.IsAny<string>())).Returns(Task.FromResult(new List<Model.Notification>()));

            NotificationHandler notificationAdaptorRepostitory = new NotificationHandler(mockNotificationHandlerObject.Object);

            var result = notificationAdaptorRepostitory.GetNotification("chaitali");

            Assert.NotNull(result);
        }
        #endregion

        [Fact]
        public void Check_For_GetUserData_From_Bussiness_Layer()
        #region
        {
            DataContract.User credential = new DataContract.User { UserName="chaitali", Password="123456789"};
            Mock<IUserManager> mockObject = new Mock<IUserManager>();
            mockObject.Setup(handler => handler.GetUser(It.IsAny<Model.User>())).Returns(Task.FromResult(true));

            UserHandler userHandler = new UserHandler(mockObject.Object);
           var result= userHandler.GetUser(credential);
            Task.Equals(true, result);
            }
        #endregion
        [Fact]
        public void Check_For_GetUserData_From_Bussiness_layer_If_PassWord_Is_Wrong()
        #region
        {
            DataContract.User credential = new DataContract.User { UserName = "chaitali", Password = "1256789" };
            Mock<IUserManager> mockObject = new Mock<IUserManager>();
            mockObject.Setup(handler => handler.GetUser(It.IsAny<Model.User>())).Returns(Task.FromResult(false));

            UserHandler userHandler = new UserHandler(mockObject.Object);
            var result = userHandler.GetUser(credential);

            Task.Equals(false,result);
        }
        #endregion
        [Fact]
        public void Check_For_SendUser_Data()
        #region
        {
            DataContract.User credential = new DataContract.User { UserName = "chaitali", Password = "123456789" };
            Mock<IUserManager> mockObject = new Mock<IUserManager>();
            mockObject.Setup(handler => handler.SubscribeUser(It.IsAny<Model.User>())).Returns(Task.FromResult(true));
            UserHandler userHandler = new UserHandler(mockObject.Object);
            var result =userHandler.Subscriber(credential);
            Task.Equals(true,result);
        }
        #endregion
        [Fact]
        public void Check_For_SendUser_Data_Which_Exist()
        #region
        {
            DataContract.User credential = new DataContract.User { UserName = "chaitali", Password = "123456789" };
            Mock<IUserManager> mockObject = new Mock<IUserManager>();
            mockObject.Setup(handler => handler.SubscribeUser(It.IsAny<Model.User>())).Returns(Task.FromResult(false));
            UserHandler userHandler = new UserHandler(mockObject.Object);
            var result = userHandler.Subscriber(credential);
            Task.Equals(true,result);
        }
        #endregion
        [Fact]
        public void Check_For_GetCount_Of_Unread_Messages()
        #region
        {
            Mock<INotificationManager> mockNotificationManager = new Mock<INotificationManager>();
            mockNotificationManager.Setup(manage => manage.GetUnreadNotificationCountFromDataBase(It.IsAny<string>())).Returns(Task.FromResult(1));

            NotificationHandler handler = new NotificationHandler(mockNotificationManager.Object);
            var result =handler.GetCountOfUnreadMessage("Chaitali");
            Task.Equals(1, result);
        }
        #endregion

        [Fact]
        public void Check_For_GetCount_Of_Unread_Messages_If_zero()
        #region
        {
            Mock<INotificationManager> mockNotificationManager = new Mock<INotificationManager>();
            mockNotificationManager.Setup(manage => manage.GetUnreadNotificationCountFromDataBase(It.IsAny<string>())).Returns(Task.FromResult(0));

            NotificationHandler handler = new NotificationHandler(mockNotificationManager.Object);
            var result = handler.GetCountOfUnreadMessage("Chaitali");
            Task.Equals(0, result);
        }
        #endregion

        
    }
}
