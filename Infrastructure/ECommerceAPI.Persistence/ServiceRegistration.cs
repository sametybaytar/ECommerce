using ECommerceAPI.Application.Repositories;
using ECommerceAPI.Persistence.Contexts;
using ECommerceAPI.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace ECommerceAPI.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices (this IServiceCollection services)
        {
            services.AddDbContext<ECommerceAPIDbContext>(option => option.UseNpgsql(Configuration.ConfigurationString));
            services.AddScoped<IProductReadRepository, ProductReadRepository>();
            services.AddScoped<IProductWriteRepository, ProductWriteRepository>();
            services.AddScoped<IOrderReadRepository, OrderReadRepository>();
            services.AddScoped<IOrderWriteRepository, OrderWriteRepository>();
            services.AddScoped<ICustomerReadRepository, CustomerReadRepository>();
            services.AddScoped<ICustomerWriteRepository, CustomerWriteRepository>();

        }
    }
}
