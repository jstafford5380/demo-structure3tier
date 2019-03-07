using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Structure3TierDemo.Api.Installers
{
    public static class ConfigurationInstaller
    {
        public static void AddAppConfigurations(this IServiceCollection services, IConfiguration config)
        {
            services.AddOptions();
            services.Configure<SampleConfig>(options => config.GetSection("SampleConfigBlock").Bind(options));
        }
    }
}