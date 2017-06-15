using BussinessLogic;
using DataAccessLayer;
using Model;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TranslatorTest
{
    public class BussinessLogicTestCases
    {
        [Fact]
        public void Check_For_Bussiness_Logic_For_InsertMethod()
        #region
        {
            Notification notification = new Notification
            {
               
                Message = "This is the mocking object to test",
                Date = DateTime.Now
            };
            Mock<INotificationStore> mockNotificationStoreObject = new Mock<INotificationStore>();
            mockNotificationStoreObject.Setup(store => store.InsertNotificationAsync(notification)).Returns(Task.FromResult(true));

            NotificationManager notificationHandler = new NotificationManager(mockNotificationStoreObject.Object);

            var result = notificationHandler.InsertNotificationToDatabase(notification);

            Task.Equals(true, result);
        }
        #endregion  
        [Fact]
        public void Check_For_Bussiness_Logic_For_Get_All_Notification()
        #region
        {
            List<Notification> notification = new List<Notification> {
            new Notification{
               
                Message = "This is the mocking object to test",
                Date = DateTime.Now
            }};
            Mock<INotificationStore> mockNotificationStoreObject = new Mock<INotificationStore>();
            mockNotificationStoreObject.Setup(store => store.GetAllNotificationAsync(It.IsAny<string>())).Returns(Task.FromResult(notification));
            NotificationManager notificationHandler = new NotificationManager(mockNotificationStoreObject.Object);
            var result = notificationHandler.GetNotificationFromDatabase("chaitali");
            Assert.NotNull(result);
        }
        #endregion
        [Fact]
        public void Check_For_Bussiness_Logic_To_Insert_Data()
        #region
        {
            Mock<IUser> mockObject = new Mock<IUser>();
            mockObject.Setup(manager => manager.AddUserAsync(It.IsAny<Model.User>())).Returns(Task.FromResult(true));

            UserManager userManager = new UserManager(mockObject.Object);
            var result = userManager.SubscribeUser(new User { UserName = "ritu", Password = "123", _id = "12345" });
            Task.Equals(true,result);
        }
        #endregion
        [Fact]
        public void Check_For_Bussiness_Layer_To_Get_User()
        #region
        {
            User credential = new User { UserName = "ritu", Password = "123", _id = "12345" };
            Mock<IUser> mockObject = new Mock<IUser>();
            mockObject.Setup(manager => manager.GetUserDetailsAsync(It.IsAny<string>())).Returns(Task.FromResult(credential));

            UserManager userManager = new UserManager(mockObject.Object);
            var result = userManager.GetUser(new User { UserName = "ritu", Password = "123", _id = "12345" });

            Task.Equals(true,result);
        }
        #endregion
        [Fact]
        public void Check_for_Bussiness_layer_To_Get_User_With_Wrong_Password()
        #region
        {
            User credential = new User { UserName = "ritu", Password = "123", _id = "12345" };
            Mock<IUser> mockObject = new Mock<IUser>();
            mockObject.Setup(manager => manager.GetUserDetailsAsync(It.IsAny<string>())).Returns(Task.FromResult(credential));
            UserManager userManager = new UserManager(mockObject.Object);
            var result = userManager.GetUser(new User { UserName = "ritu", Password = "12345", _id = "12345" });

            Task.Equals(false,result);
        }
        #endregion
        [Fact]
        public void Check_For_Bussiness_Layer_To_Get_Count_Of_UnreadMessage()
        #region
        {
            Mock<INotificationStore> mockDataLayer = new Mock<INotificationStore>();
            mockDataLayer.Setup(count => count.GetUnreadMessageCountAsync(It.IsAny<string>())).Returns(Task.FromResult(1));

            NotificationManager notificationManager = new NotificationManager(mockDataLayer.Object);
            var result =notificationManager.GetUnreadNotificationCountFromDataBase("Ritu");
            Task.Equals(1, result);
        }
        #endregion
        [Fact]
        public void Check_If_There_Is_No_Unread_Notification()
        #region
        {
            Mock<INotificationStore> mockDataLayer = new Mock<INotificationStore>();
            mockDataLayer.Setup(count => count.GetUnreadMessageCountAsync(It.IsAny<string>())).Returns(Task.FromResult(0));

            NotificationManager notificationManager = new NotificationManager(mockDataLayer.Object);
            var result = notificationManager.GetUnreadNotificationCountFromDataBase("Ritu");
            Task.Equals(0, result);
        }
        #endregion
    }
}
