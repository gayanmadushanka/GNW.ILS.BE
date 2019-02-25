using GNW.ILS.API;

namespace GNW.ILS.WPF.Services
{
    public class UserDataService : IUserDataService
    {
        private readonly IUserAPI _userApi;
        public UserDataService(IUserAPI userApi)
        {
            _userApi = userApi;
        }

        public bool CheckUserAuthentication(string userName, string password)
        {
            return _userApi.CheckUserAuthentication(userName, password);
        }
    }
}
