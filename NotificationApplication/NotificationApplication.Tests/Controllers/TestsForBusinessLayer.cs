using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using Model;
using DataAccess.DataAccessComponents;
using Moq;
using BusinessLogic.BusinessWorkflow;
using System.Collections.Generic;

namespace NotificationApplication.Tests.Controllers
{
    [TestClass]
    public class TestsForBusinessLayer
    {
        [TestMethod]
        public async Task TestForSendNotificationToUser()
        {
            var objectTobeSentFromDataLayer = new Notification()
            {
                Message = "Himani posted on your wall"
            };
            var objectToBeSentinBusinessLayer = new Notification()
            {
                Message = "Himani posted on your wall"
            };
            Mock<IAppUser> data = new Mock<IAppUser>();
            data.Setup(mock => mock.SaveNotificationToDB(It.IsAny<Notification>())).Returns(Task.FromResult(objectTobeSentFromDataLayer));
            NotificationManager services = new NotificationManager(data.Object);
            var expectedOutput = await services.PushNotificationsAsync(objectToBeSentinBusinessLayer);

            Assert.AreEqual(expectedOutput.Id, objectToBeSentinBusinessLayer.Id);
            Assert.AreEqual(expectedOutput.Message, objectToBeSentinBusinessLayer.Message);
        }

       [TestMethod]
        public async Task TestForGetAllNotificationsFromDB()
        {
            List<Notification> listOfNotifications = new List<Notification>();
            Notification notify = new Notification() { Message = "hello" };
            listOfNotifications.Add(notify);
            Mock<IAppUser> mocked = new Mock<IAppUser>();
            mocked.Setup(mock => mock.GetNotificationFromDB("hverma")).Returns(Task.FromResult(listOfNotifications));
            NotificationManager manager = new NotificationManager(mocked.Object);
            var expectedOutput = await manager.GetNotificationsAsync("hverma");
            CollectionAssert.AreEqual(listOfNotifications, expectedOutput);
        }

        [TestMethod]
        public async Task TestForUserAuthentication()
        {
            User user = new User()
            {
                Email = "dverma",
                Password = "abcdef"
            };
            Mock<IUserAuthenticationCheck> mocked = new Mock<IUserAuthenticationCheck>();
            mocked.Setup(mock => mock.AuthenticateUser(user)).Returns(true);
            UserAuthenticationManagementService manager = new UserAuthenticationManagementService(mocked.Object);
            var expectedOutput =  manager.AuthenticateUser(user);
            Assert.IsTrue(expectedOutput);

        }
        [TestMethod]
        public async Task TestForGetUnreadNotificationCount()
        {
            Mock<IAppUser> manager = new Mock<IAppUser>();
            manager.Setup(x => x.GetUnreadNotificationCount("hverma")).Returns(Task.FromResult(5));
            NotificationManager service = new NotificationManager(manager.Object);
            var expectedCount = service.GetUnreadNotificationCount("hverma").GetAwaiter().GetResult();
            Assert.AreEqual(expectedCount, 5);

        }
        [TestMethod]
        public void TestForChangePassword()
        {

            
            User Buser = new User()
            {
                Email = "dverma",
                Password = "abcdef"
            };
            Mock<IUserAuthenticationCheck> manager = new Mock<IUserAuthenticationCheck>();
            manager.Setup(x => x.ChangePassword(Buser, "abcdefgh")).Returns(true);

            UserAuthenticationManagementService service = new UserAuthenticationManagementService(manager.Object);
            var expectedOutput = service.ChangePassword(Buser, "abcdefgh");

            Assert.IsTrue(expectedOutput);
        }
    }
}
