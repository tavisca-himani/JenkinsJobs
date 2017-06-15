using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using ServiceLayer.ServiceImplementation;
using Moq;
using ServiceLayer.Translator;
using BusinessLogic.BusinessComponents;
using Model;
using BusinessLogic.BusinessWorkflow;
using ServiceLayer.ServiceContract;

namespace NotificationApplication.Tests.Controllers
{
    [TestClass]
    public class TestsForServiceLayer
    {

        public TestsForServiceLayer()
        {

        }

        [TestMethod]
        public async Task TestForSendNotificationToUser()
        {
            var objectTobeSentinBusinessLayer = new Notification()
            {
                Message = "Himani posted on your wall"
            };
            var objectToBeSentinServiceLayer = new ServiceLayer.DataContract.Notification()
            {
                Message = "Himani posted on your wall"
            };
            Mock<INotificationManager> manager = new Mock<INotificationManager>();
            manager.Setup(mock => mock.PushNotificationsAsync(It.IsAny<Notification>())).Returns(Task.FromResult(objectTobeSentinBusinessLayer));
            NotificationServices services = new NotificationServices(manager.Object);
            var expectedOutput = await services.PushNotificationsAsync(objectToBeSentinServiceLayer);

            Assert.AreEqual(expectedOutput.Id, objectToBeSentinServiceLayer.Id);
            Assert.AreEqual(expectedOutput.Message, objectToBeSentinServiceLayer.Message);
        }

        [TestMethod]
        //test for translator that will convert my datacontract to domain model
        public void TestForConvertingDataContractToDomainModel()
        {
            var objectToBeSentFromServiceLayer = new ServiceLayer.DataContract.Notification()
            {
                Message = "Himani posted on your wall"
            };
            var objectTobeSentinBusinessLayer = new Notification()
            {
                Message = "Himani posted on your wall"
            };

            var translator = Convertor.ToDomainModel(objectToBeSentFromServiceLayer);
            Assert.AreEqual(objectTobeSentinBusinessLayer.Id, translator.Id);
            Assert.AreEqual(objectTobeSentinBusinessLayer.Message, translator.Message);

        }
        [TestMethod]
        //test for translator that will convert my domainModel to dataContract
        public void TestForConvertingDomainModelToDataContract()
        {
            var objectToBeSentinServiceLayer = new ServiceLayer.DataContract.Notification()
            {
                Message = "Himani posted on your wall"
            };
            var objectTobeSentFromBusinessLayer = new Notification()
            {
                Message = "Himani posted on your wall"
            };

            var translator = Convertor.ToDataContract(objectTobeSentFromBusinessLayer);
            Assert.AreEqual(objectToBeSentinServiceLayer.Id, translator.Id);
            Assert.AreEqual(objectToBeSentinServiceLayer.Message, translator.Message);
            
        }

        [TestMethod]
        public async Task TestForGetAllNotifications()
        {
            List<Notification> listOfNotifications = new List<Notification>();
            Mock<INotificationManager> manager = new Mock<INotificationManager>();
            manager.Setup(mock => mock.GetNotificationsAsync("hverma")).Returns(Task.FromResult(listOfNotifications));
            NotificationServices services = new NotificationServices(manager.Object);
            var expectedOutput = await services.GetNotificationsAsync("hverma");
            CollectionAssert.AreEqual(listOfNotifications, expectedOutput);

        }
        [TestMethod]
        public async Task TestForUserAuthenticationinServiceLayer()
        {
            ServiceLayer.DataContract.User user = new ServiceLayer.DataContract.User()
            {
                Email = "dverma",
                Password = "abcdef"
            };
            User Buser = new User()
            {
                Email = "dverma",
                Password = "abcdef"
            };
            Mock<IUserAuthenticationManager> manager = new Mock<IUserAuthenticationManager>();
            manager.Setup(x => x.AuthenticateUser(It.IsAny<User>())).Returns(true);

            UserAuthenticationService service = new UserAuthenticationService(manager.Object);
            var expectedOutput = service.AuthenticateUser(user);

            Assert.IsTrue(expectedOutput);
           
        }
        [TestMethod]
        public async Task  TestForGetUnreadNotificationCount()
        {
            Mock<INotificationManager> manager = new Mock<INotificationManager>();
            manager.Setup(x => x.GetUnreadNotificationCount("hverma")).Returns(Task.FromResult(5));
            NotificationServices service = new NotificationServices(manager.Object);
            var expectedCount = service.GetUnreadNotificationCount("hverma").GetAwaiter().GetResult();
            Assert.AreEqual(expectedCount, 5);

        }

        public void TestForChangePassword()
        {

            ServiceLayer.DataContract.User user = new ServiceLayer.DataContract.User()
            {
                Email = "dverma",
                Password = "abcdef"
            };
            User Buser = new User()
            {
                Email = "dverma",
                Password = "abcdef"
            };
            Mock<IUserAuthenticationManager> manager = new Mock<IUserAuthenticationManager>();
            manager.Setup(x => x.ChangePassword(Buser, "abcdefgh")).Returns(true);

            UserAuthenticationService service = new UserAuthenticationService(manager.Object);
            var expectedOutput = service.ChangePassword(user, "abcdefgh");

            Assert.IsTrue(expectedOutput);
        }
        


    }
}

