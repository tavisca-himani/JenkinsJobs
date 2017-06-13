//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net.Http;
//using System.Text;
//using System.Web.Http;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using NotificationApplication;
//using NotificationApplication.Controllers;
//using Moq;
//using BusinessLogic.BusinessComponents;
//using ServiceLayer.ServiceImplementation;
//using System.Threading.Tasks;

//namespace NotificationApplication.Tests.Controllers
//{
//    [TestClass]
//    public class ValuesControllerTest
//    {
//        [TestMethod]
//        public async Task TestForSendNotificationToUser()
//        {
//            var objectTobeSentinBusinessLayer = new Notification()
//            {
//                Message = "Himani posted on your wall"
//            };
//            var objectToBeSentinServiceLayer = new ServiceLayer.DataContract.Notification()
//            {
//                Message = "Himani posted on your wall"
//            };
//            Mock<INotificationManager> manager = new Mock<INotificationManager>();
//            manager.Setup(mock => mock.PushNotificationsAsync(It.IsAny<Notification>())).Returns(Task.FromResult(objectTobeSentinBusinessLayer));
//            NotificationServices services = new NotificationServices(manager.Object);
//            var expectedOutput = await services.PushNotificationsAsync(objectToBeSentinServiceLayer);

//            Assert.AreEqual(expectedOutput.Id, objectToBeSentinServiceLayer.Id);
//            Assert.AreEqual(expectedOutput.Message, objectToBeSentinServiceLayer.Message);
//        }
//    }

//    [TestMethod]
//    public void Get()
//    {
//        // Arrange
//        ValuesController controller = new ValuesController();

//        // Act
//        IEnumerable<string> result = controller.Get();

//        // Assert
//        Assert.IsNotNull(result);
//        Assert.AreEqual(2, result.Count());
//        Assert.AreEqual("value1", result.ElementAt(0));
//        Assert.AreEqual("value2", result.ElementAt(1));
//    }

//    [TestMethod]
//    public void GetById()
//    {
//        // Arrange
//        ValuesController controller = new ValuesController();

//        // Act
//        string result = controller.Get(5);

//        // Assert
//        Assert.AreEqual("value", result);
//    }

//    [TestMethod]
//    public void Post()
//    {
//        // Arrange
//        ValuesController controller = new ValuesController();

//        // Act
//        controller.Post("value");

//        // Assert
//    }

//    [TestMethod]
//    public void Put()
//    {
//        // Arrange
//        ValuesController controller = new ValuesController();

//        // Act
//        controller.Put(5, "value");

//        // Assert
//    }

//    [TestMethod]
//    public void Delete()
//    {
//        // Arrange
//        ValuesController controller = new ValuesController();

//        // Act
//        controller.Delete(5);

//        // Assert
//    }
//}
//    }
//}
