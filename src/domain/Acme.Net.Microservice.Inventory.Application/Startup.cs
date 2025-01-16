using CodeDesignPlus.Net.Core.Abstractions;
using Acme.Net.Microservice.Inventory.Application.Setup;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Acme.Net.Microservice.Inventory.Application
{
    public class Startup : IStartup
    {
        public void Initialize(IServiceCollection services, IConfiguration configuration)
        {
            MapsterConfigInventory.Configure();
        }
    }
}
