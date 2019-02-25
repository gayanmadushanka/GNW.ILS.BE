using GNW.ILS.DAL.Entity;

namespace GNW.ILS.API
{
    public interface IUserAPI
    {
        bool CheckUserAuthentication(string userName, string password);
    }
}
