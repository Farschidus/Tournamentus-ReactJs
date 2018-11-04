using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Tournamentus.Api.Extensions;
using Tournamentus.Api.Infrastructure;
using Tournamentus.Api.Security;
using Tournamentus.Core.Api;
using StructureMap;
using System;

namespace Tournamentus.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; }

        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        // This method gets called by the runtime. Use this method to add services to the container.
        public IServiceProvider ConfigureServices(IServiceCollection services)
        {
            var settings = services.ConfigureAppSetting<AppSettings>(Configuration.GetSection("Settings"));

            services.AddCors();
            services.AddMvc(options =>
            {
                // Add authorize filter to authorize users who have access to application
                options.Filters.Add(new AuthorizeFilter(new AuthorizationPolicies().IsAuthenticated()));
                options.Filters.Add(new ProducesAttribute("application/json"));
            })
            .AddControllersAsServices();

            services.AddSecurity(settings);
            
            return ConfigureIoC(services, settings);
        }

        public IServiceProvider ConfigureIoC(IServiceCollection services, AppSettings settings)
        {
            var container = new Container();

            container.Configure(config =>
            {
                config.AddRegistry(new ApiRegistry(settings));
                config.Populate(services);
            });

            container.AssertConfigurationIsValid();

            return container.GetInstance<IServiceProvider>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler();
            }

            app.UseAuthentication();

            app.UseCors(builder => { builder
                .AllowAnyHeader()
                .AllowAnyMethod()
                .AllowAnyOrigin();
            });

            // Usfeful for future error handeling
            //app.UseExceptionHandler(new ExceptionHandlerOptions
            //{
            //    ExceptionHandler = new JsonExceptionMiddleware(env).Invoke
            //});

            app.UseMvc();
        }
    }
}
