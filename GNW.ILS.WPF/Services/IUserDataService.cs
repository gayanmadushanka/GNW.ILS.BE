namespace GNW.ILS.WPF.Services
{
    public interface IUserDataService
    {
        bool CheckUserAuthentication(string userName, string password);
    }
}
