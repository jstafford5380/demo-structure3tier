using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Structure3TierDemo.Domain.BoundedContext1;
using Structure3TierDemo.Domain.BoundedContext1.Service;
using Structure3TierDemo.Infrastructure.Sql.BoundedContext1;

namespace Structure3TierDemo.Api.Installers
{
    public static class DomainServiceInstaller
    {
        public static void AddDomainServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddTransient<IDealWithFoo, FooService>();
            services.AddTransient<IFooRepository, FooRepository>();
        }
    }

    public static class ConfigurationInstaller
    {
        public static void AddAppConfigurations(this IServiceCollection services, IConfiguration config)
        {
            services.AddOptions();
            services.Configure<SampleConfig>(options => config.GetSection("SampleConfigBlock").Bind(options));
        }
    }

    public class SampleConfig
    {
        public string Prop1 { get; set; }

        public InnerConfig Inner1 { get; set; }


        public class InnerConfig
        {
            public string InnerProp { get; set; }
        }
    }

    
}
