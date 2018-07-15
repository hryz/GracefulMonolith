using System;
using Application.Abstract;
using Data.Write.Catalog.Repositories;
using Data.Write.Customers.Repositories;
using Domain.Catalog;
using Domain.Customer;
using Microsoft.Extensions.DependencyInjection;

namespace Data.Write
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddDataWriteServices(this IServiceCollection services)
        {
            //Poor man IoC module, TODO: replace it by AutoFac

            return services
                .AddTransient<IRepository<Customer, Guid>, CustomerRepository>()
                .AddTransient<IRepository<Product, Guid>, ProductRepository>();
        }
    }
}
