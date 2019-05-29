using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Mvc.Versioning;
using Swashbuckle.AspNetCore.Swagger;
using Core.DependencyInjection;
using Microsoft.AspNetCore.Mvc;
using Api.Web.Controllers;
using Api.Web.Middleware;

namespace Api.Web
{
    public class Startup
    {
        public Startup(IHostingEnvironment env)
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(env.ContentRootPath)
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddJsonFile($"appsettings.{env.EnvironmentName}.json", optional: true)
                .AddEnvironmentVariables();
            Configuration = builder.Build();
        }

        public IConfigurationRoot Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            // Add framework services.
            var service = new CompositionRoot();
            var serviceProvider = services.BuildServiceProvider();
            service.Register(serviceProvider, services, Configuration);

            services.AddMvc();

            services.AddApiVersioning(
                options =>
                {
                    options.ReportApiVersions = true;
                    options.AssumeDefaultVersionWhenUnspecified = true;
                    options.ApiVersionReader = new MediaTypeApiVersionReader();
                    options.DefaultApiVersion = new ApiVersion(1, 0);
                    options.Conventions.Controller<PaymentsController>().HasApiVersion(new ApiVersion(1, 0));
                });

            services.AddSwaggerGen(opt =>
            {
                opt.SwaggerDoc("v1", new Info
                {
                    Title = "Payment Gateway API",
                    Version = "v1",
                    Description = "Payment Gateway API"
                });
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            app.UseMvc();

            app.UseSwagger();
            app.UseSwaggerUI(action =>
            {
                action.RoutePrefix = "swagger/v1/ui";
                action.SwaggerEndpoint("/swagger/v1/swagger.json", "Payment Gateway API");
            });

            app.UseMiddleware<AuthenticationMiddleware>();

        }
    }
}
