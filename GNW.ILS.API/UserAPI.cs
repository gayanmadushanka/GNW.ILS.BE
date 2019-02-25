using GNW.ILS.BL;
using GNW.ILS.DAL.Contract;

namespace GNW.ILS.API
{
    public class UserAPI : IUserAPI
    {
        private readonly IUnitOfWork _unitOfWork;

        public UserAPI(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public bool CheckUserAuthentication(string userName, string password)
        {
            var userDetailBL = new UserDetailBL(_unitOfWork);
            return userDetailBL.CheckUserAuthentication(userName, password);
        }
    }
}
