using GNW.ILS.API.Contract;

namespace GNW.ILS.WPF.Services
{
    public class MatterService : IMatterService
    {
        private readonly IMatterManagerApi _matterManagerApi;

        public MatterService(IMatterManagerApi matterManagerApi)
        {
            _matterManagerApi = matterManagerApi;
        }
    }
}
