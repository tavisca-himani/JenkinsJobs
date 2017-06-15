using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataContract;
using Model;
using BussinessLogic;

namespace NotificationAdaptor
{
    public class UserHandler : IUserHandler
    {
        private IUserManager _userManager;

        public UserHandler(IUserManager userManager)
        {
            _userManager = userManager;
        }

        public async Task<List<DataContract.User>> GetAllUser()
        {
            List<DataContract.User> listResult = new List<DataContract.User>();
            var result = await _userManager.GetAllUser();
            foreach (var user in result)
                listResult.Add(ObjectTranslator.ConvertObjectToDataContract.ToCredentialsModel(user));
            return listResult;
        }

        public async Task<bool> GetUser(DataContract.User credentials)
        {
            return await _userManager.GetUser(ObjectTranslator.ConvertObjectToBussinessModel.ToCredentialsDomain(credentials));

        }

        public async Task<bool> Subscriber(DataContract.User credentials)
        {
            return await _userManager.SubscribeUser(ObjectTranslator.ConvertObjectToBussinessModel.ToCredentialsDomain(credentials));
        }
    }
}
