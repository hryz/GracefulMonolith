using System.Data.SqlClient;
using Application.Abstract;
using AutoMapper;
using Dapper.Logging;
using Data.Read.Abstract;
using Data.Write;
using Data.Write.Catalog;
using Data.Write.Customers;
using Data.Write.Customers.Mappers;
using FluentValidation.AspNetCore;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Swashbuckle.AspNetCore.Swagger;
using WebApi.Infrastructure;

namespace WebApi
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            var conStr = Configuration.GetConnectionString("DefaultConnection");

            services
                .AddDbConnectionFactory(prv => new SqlConnection(conStr)) //dapper
                .AddDbContext<CustomerDataContext>(x => x.UseSqlServer(conStr)) //ef
                .AddDbContext<CatalogDataContext>(x => x.UseSqlServer(conStr)) //ef
                .AddMediatR(typeof(ICommand<>), typeof(IQuery<>))
                .AddAutoMapper(typeof(CustomerMapper))
                .AddDataWriteServices()
                .AddMvc()
                .AddFluentValidation(val => val
                    .RegisterValidatorsFromAssemblyContaining(typeof(ICommand<>))
                    .RegisterValidatorsFromAssemblyContaining(typeof(IQuery<>)))
                .SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info {Title = "Graceful Monolith", Version = "v1"});
                c.DescribeAllEnumsAsStrings();
                c.SchemaFilter<SwaggerFluentValidationProvider>();
                c.SchemaFilter<SwaggerSampleModelProvider>();
                c.OperationFilter<SwaggerAuthDefinitionProvider>();
            });
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            app.UseSwagger().UseSwaggerUI(x => x.SwaggerEndpoint("/swagger/v1/swagger.json", "Graceful Monolith"));

            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }

    
}
