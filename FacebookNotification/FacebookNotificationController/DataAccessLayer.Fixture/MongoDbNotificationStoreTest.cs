using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using Xunit;

namespace DataAccessLayer.Fixture
{
    public class MongoDbNotificationStoreTest
    {

        [Fact]
    public void Check_For_Data_Is_Inserted()
    {
        Model.Notification notification = new Model.Notification
        {
           
            Message = "This is the test to check if the data is properly inserted in database",
            Date = DateTime.Now
        };
        INotificationStore store = new NotificationRepository();

        var result = store.InsertNotificationAsync(notification);

        Task.Equals(true, result);
    }
        //[Fact]
        //public async Task Check_For_Data_Is_Inserted_NotificationID_Is_present()
        //{
        //    Model.Notification notification = new Model.Notification
        //    {
               
        //        Message = "",
        //        Date = DateTime.Now
        //    };
        //    INotificationStore store = new NotificationRepository();
        // await   Assert.ThrowsAsync<Exception>(async () => await store.InsertNotificationAsync(notification));
        //}

  

    [Fact]
    public void Check_For_Data_To_Retrieved_All_Data()
    {
        INotificationStore store = new NotificationRepository();
        var result = store.GetAllNotificationAsync("chaitali");
            Assert.NotNull(result);
        }
}
}
