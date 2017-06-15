using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace DataAccessLayer.Fixture
{
    public class CredentialsTestCases
    {
        [Fact]
        public void Check_If_User_Is_Inserted_If_Already_User_Exits()
        #region
        {
            Model.User credentials = new Model.User { UserName ="Chaitali" , Password = "12345678"};
            IUser user = new UserDataRepository();
            var result =user.AddUserAsync(credentials);
            Task.Equals(false,result);
        }
        #endregion
        [Fact]
       
        public void Check_If_User_Is_Inserted_Properly()
        #region
        {
            Model.User credentials = new Model.User { UserName = "Chaitali", Password = "12345678" };
            IUser user = new UserDataRepository();
            var result = user.AddUserAsync(credentials);
            Task.Equals(false,result);
        }
        #endregion
        [Fact]
        public void Check_If_User_Exits()
        #region
        {
            IUser user = new UserDataRepository();

            var result = user.GetUserDetailsAsync("Chaitali");

            Task.Equals(true,result);
        }
        #endregion
        [Fact]
        public async void Check_If_User_Dont_Exits()
        #region
        {
            IUser user = new UserDataRepository();

            await Assert.ThrowsAsync<Exception>(async () =>await user.GetUserDetailsAsync("kunal"));
        }
        #endregion
    }
}
