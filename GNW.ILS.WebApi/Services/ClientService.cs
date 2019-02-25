using GNW.ILS.API.Contract;

namespace GNW.ILS.WebApi.Services
{
    public class ClientService : IClientService
    {
        private readonly IClientManagerApi _clientManagerApi;

        public ClientService(IClientManagerApi clientManagerApi)
        {
            _clientManagerApi = clientManagerApi;
        }

        public void GetClients()
        {
        }
    }
}
