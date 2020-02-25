using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bogus;
using Domain;
using Infrastructure;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using FluentValidation.AspNetCore;
using Domain.Validators;
using Microsoft.EntityFrameworkCore;

namespace Api
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddScoped<ICustomerRepository, FakeCustomerRepository>();
            services.AddScoped<Faker<Customer>, CustomerFaker>();
            services.AddScoped<IMessageService, SmsMessageService>();
            services.AddScoped<IMessageService, EmailMessageService>();

            // dotnet add package FluentValidation.AspNetCore

            services.Configure<CustomerOptions>(Configuration.GetSection("CustomerOptions"));

            string connectionString = Configuration.GetConnectionString("MyConnection");

            services.AddDbContext<CustomersContext>(options =>
            options.UseSqlServer(connectionString));

            services.AddControllers()
                .AddFluentValidation(options => options.RegisterValidatorsFromAssemblyContaining<CustomerValidator>());
        }

       

            // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsEnvironment("Testing"))
            {
                app.UseDeveloperExceptionPage();
            }

            string url = Configuration["GoogleUrl"];

            string smsUrl = Configuration["SmsService:Url"];

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
