using GNW.ILS.API.Contract;
using Microsoft.Extensions.DependencyInjection;

namespace GNW.ILS.API
{
    public static class ServiceCollectionExtensions
    {
        public static void AddManagerApi(this IServiceCollection services)
        {
            services.AddTransient<IClientManagerApi, ClientManagerApi>();
            services.AddTransient<IMatterManagerApi, MatterManagerApi>();
        }
    }
}
