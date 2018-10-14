using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using StructureMap;
using System;
using Tournamentus.Api.Extensions;
using Tournamentus.Api.Infrastructure;
using Tournamentus.Core;

namespace Tournamentus.Api
{
    public class Startup
    {
        public IConfiguration Configuration { get; set; }

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
                // options.Filters.Add(new AuthorizeFilter(new AuthorizationPolicies().IsParticipant()));
                options.Filters.Add(new ProducesAttribute("application/json"));
            })
            .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
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

            // container.AssertConfigurationIsValid();

            return container.GetInstance<IServiceProvider>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
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

            app.UseCors(builder => builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader());

            // Usfeful for future error handeling
            app.UseExceptionHandler(new ExceptionHandlerOptions
            {
                ExceptionHandler = new JsonExceptionMiddleware(env).Invoke
            });

            app.UseAuthentication();
            app.UseHttpsRedirection();
            app.UseMvc();
        }
    }
}
