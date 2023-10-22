using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace ECommerceAPI.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            //services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(Assembly.GetExecutingAssembly()));
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(typeof(ServiceRegistration).GetTypeInfo().Assembly));
           // IServiceCollection serviceCollection = services.AddMediatR(cfg => {
                //cfg.RegisterServicesFromAssembly(typeof(ServiceRegistration).Assembly);
            //});
        }
    }
}
