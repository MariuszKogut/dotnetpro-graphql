using System;
using FluentValidation;
using HotChocolate;
using HotChocolate.AspNetCore;
using HS.CustomerApp.CustomerHost.GraphQlTypes;
using HS.CustomerApp.CustomerHost.Logic;
using HS.CustomerApp.CustomerHost.Models;
using HS.CustomerApp.HostConfiguration;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace HS.CustomerApp.CustomerHost
{
    public class Startup
    {
        readonly string CorsPolicyName = "CorsPolicy";

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCustomizedApplicationInsightsTelemetry(Configuration, "CustomerHost", Environment.MachineName);
            services.AddCors(options =>
            {
                options.AddPolicy(CorsPolicyName,
                    builder =>
                    {
                        builder
                            .WithOrigins("http://localhost:3000")
                            .AllowAnyMethod()
                            .AllowAnyHeader();
                    });
            });

            services.AddSingleton<ICustomerService, CustomerService>();
            services.AddSingleton<IPersonService, PersonService>();
            services.AddSingleton<IAddressService, AddressService>();
            services.AddTransient<IValidator<CustomerModel>, CustomerValidator>();

            services.AddGraphQL(
                SchemaBuilder.New()
                    .AddQueryType<QueryType>()
            );
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(CorsPolicyName);
            app.UseHttpsRedirection();
            app.UseRouting();

            app.UseGraphQL();
            app.UseGraphiQL();
        }
    }
}