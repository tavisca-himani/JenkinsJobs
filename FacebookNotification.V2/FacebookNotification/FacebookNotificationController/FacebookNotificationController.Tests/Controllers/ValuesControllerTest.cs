//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Net.Http;
//using System.Text;
//using System.Web.Http;
//using Microsoft.VisualStudio.TestTools.UnitTesting;
//using FacebookNotificationController;
//using FacebookNotificationController.Controllers;

//namespace FacebookNotificationController.Tests.Controllers
//{
//    [TestClass]
//    public class ValuesControllerTest
//    {
//        [TestMethod]
//        public void Get()
//        {
//            // Arrange
//            FacebookNotificationController.Controllers.FacebookNotificationController controller = new FacebookNotificationController.Controllers.FacebookNotificationController();

//            // Act
//            IEnumerable<string> result = controller.Get();

//            // Assert
//            Assert.IsNotNull(result);
//            Assert.AreEqual(2, result.Count());
//            Assert.AreEqual("value1", result.ElementAt(0));
//            Assert.AreEqual("value2", result.ElementAt(1));
//        }

//        [TestMethod]
//        public void GetById()
//        {
//            // Arrange
//            FacebookNotificationController.Controllers.FacebookNotificationController controller = new FacebookNotificationController.Controllers.FacebookNotificationController();

//            // Act
//            string result = controller.Get(5);

//            // Assert
//            Assert.AreEqual("value", result);
//        }

//        [TestMethod]
//        public void Post()
//        {
//            // Arrange
//            FacebookNotificationController.Controllers.FacebookNotificationController controller = new FacebookNotificationController.Controllers.FacebookNotificationController();

//            // Act
//            controller.Post("value");

//            // Assert
//        }

//        [TestMethod]
//        public void Put()
//        {
//            // Arrange
//            FacebookNotificationController.Controllers controller = new FacebookNotificationController.Controllers.FacebookNotificationController();

//            // Act
//            controller.Put(5, "value");

//            // Assert
//        }

//        [TestMethod]
//        public void Delete()
//        {
//            // Arrange
//            FacebookNotificationController.Controllers.FacebookNotificationController controller = new FacebookNotificationController.Controllers.FacebookNotificationController();

//            // Act
//            controller.Delete(5);

//            // Assert
//        }
//    }
//}
