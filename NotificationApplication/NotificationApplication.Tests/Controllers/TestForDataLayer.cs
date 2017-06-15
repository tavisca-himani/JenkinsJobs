using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MongoDB.Driver;
using DataAccess.ServiceAgents;
using Model;
using System.Threading.Tasks;
using System.Collections.Generic;
using DataAccess.DataAccessComponents;
using Moq;

namespace NotificationApplication.Tests.Controllers
{
    [TestClass]
    public class TestForDataLayer
    {
        [TestMethod]
        public async Task TestforsaveToDataBaseMethod()
        {
            Notification notify = new Notification()
            {
                Message = "Himani Liked your profile picture"
            };
            Mock<IAppUser> mock = new Mock<IAppUser>();
            mock.Setup(x => x.UpdateNotificationCount());

            DBNotificationManager mongo = new DBNotificationManager();
            var expectedOutput = await mongo.SaveNotificationToDB(notify);
            Assert.AreEqual(notify.Message, expectedOutput.Message);

        }

        [TestMethod]
        public void TestForGetNotificationsForDatabase()
        {
            Mock<IAppUser> mock = new Mock<IAppUser>();
            mock.Setup(x => x.ResetNotificationCount("hverma"));
            List<Notification> listofnotifications = new List<Notification>();
            Notification notify = new Notification()
            {
                Message = "Himani posted on your wall"
            };
            listofnotifications.Add(notify);
            DBNotificationManager mongo = new DBNotificationManager();
            var expectedOutput = mongo.GetNotificationFromDB("hverma").GetAwaiter().GetResult();
            Assert.AreNotEqual(expectedOutput[0].Message, listofnotifications[0].Message);
        }
        [TestMethod]
        public void TestForUserAuthentication()
        {
            User user = new User()
            {
                Email = "hverma",
                Password = "abcd"
            };
            DBUserAuthenticationServices service = new DBUserAuthenticationServices();
            var result = service.AuthenticateUser(user);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void TestForGetUnreadNotificationCount()
        {

            DBNotificationManager service = new DBNotificationManager();
            var expectedCount = service.GetUnreadNotificationCount("hverma").GetAwaiter().GetResult();
            Assert.AreEqual(expectedCount, 0);

        }
        [TestMethod]
        public void TestForChangePassword()
        {


            User Buser = new User()
            {
                Email = "dverma",
                Password = "abcdef"
            };


            DBUserAuthenticationServices service = new DBUserAuthenticationServices();
            var expectedOutput = service.ChangePassword(Buser, "abcdefgh");

            Assert.IsTrue(expectedOutput);
        }
    }
}

