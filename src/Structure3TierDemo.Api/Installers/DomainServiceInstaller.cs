using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Structure3TierDemo.Domain.BoundedContext1;
using Structure3TierDemo.Domain.BoundedContext1.Service;
using Structure3TierDemo.Infrastructure.Sql.BoundedContext1;
using Structure3TierDemo.Infrastructure.UserService;

namespace Structure3TierDemo.Api.Installers
{
    public static class DomainServiceInstaller
    {
        public static void AddDomainServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddTransient<IFooService, FooService>();
            services.AddTransient<IFooRepository, FooRepository>();
            services.AddTransient<IUserService, UserService>();
        }
    }
}
