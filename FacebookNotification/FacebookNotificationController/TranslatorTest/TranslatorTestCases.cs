using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace TranslatorTest
{
    public class TranslatorTestCases
    {
        [Fact]

        public void Check_For_Translating_Data_Contract_To_Bussiness_Model()
        #region
        {

            DataContract.Notification notification = new DataContract.Notification
            {
              
                Message = "This is testing of the model to convert it into Bussiness Model"
            };

            Model.Notification result = ObjectTranslator.ConvertObjectToBussinessModel.ToDomain(notification);

            
            Assert.Equal(notification.Message, result.Message);
            Assert.NotNull(result.Date);
        }
        #endregion
        [Fact]
        public void Check_For_Translating_Bussiness_Model_To_Data_Contract()
        #region
        {
            Model.Notification notification = new Model.Notification
            {

               
                Message = "This is testing of the model to convert it to data contract Model",
                Date = DateTime.Now
            };

            DataContract.Notification result = ObjectTranslator.ConvertObjectToDataContract.ToModel(notification);

           
            Assert.Equal(notification.Message, result.Message);

        }
        #endregion
        [Fact]
        public void Check_For_Translating_Credentials_Model_To_Data_Contract()
        #region
        {
            Model.User credentials = new Model.User
            {
                UserName = "Chaitali",
                Password = "123456",
                _id = new Guid()
            };

            DataContract.User result = ObjectTranslator.ConvertObjectToDataContract.ToCredentialsModel(credentials);

            Assert.Equal(credentials.UserName , result.UserName);
            Assert.Equal(credentials.Password, result.Password);
        }
        #endregion
    
        [Fact]
        public void Check_For_Translating_Credentials_Model_To_Bussiness_Model()
        #region
        {
            DataContract.User credentials = new DataContract.User
            {
                UserName = "Chaitali",
                Password = "123456"
                
            };

            Model.User result = ObjectTranslator.ConvertObjectToBussinessModel.ToCredentialsDomain(credentials);

            Assert.Equal(credentials.UserName, result.UserName);
            Assert.Equal(credentials.Password, result.Password);
            Assert.NotNull(result._id);
        }
        #endregion
     
    }
}
