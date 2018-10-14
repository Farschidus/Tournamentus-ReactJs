using Tournamentus.Api.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Tournamentus.Core;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System;

namespace Tournamentus.Api.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static TConfig ConfigureAppSetting<TConfig>(this IServiceCollection services, IConfiguration configuration) where TConfig : class, new()
        {
            if (services == null) throw new ArgumentNullException(nameof(services));
            if (configuration == null) throw new ArgumentNullException(nameof(configuration));

            var config = new TConfig();
            configuration.Bind(config);
            return config;
        }

        public static IServiceCollection AddSecurity(this IServiceCollection services, AppSettings appSettings)
        {
            // configure jwt authentication
            var key = Encoding.ASCII.GetBytes(appSettings.WhoKnows);
            //
            services.AddScoped<CustomJwtBearerEvents>()
            .AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false
                };
            });

            return services;
        }
    }
}
