using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Tournamentus.Api.Security;
using Tournamentus.Core.Api;
using System;
using System.Text;

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
            var key = Encoding.ASCII.GetBytes("7NKMdsVeRrZS1Dp!h0xa1uBwt47QoWUjXWk3pyqx|");

            services.AddScoped<CustomJwtBearerEvents>()
            .AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.Events = services.BuildServiceProvider().GetService<CustomJwtBearerEvents>();
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    //ValidIssuer = appSettings.Security.Issuer,
                    ValidateAudience = false,
                    //ValidAudience = appSettings.Security.Audience,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                    //RequireExpirationTime = false,
                    //ValidateLifetime = true,
                    //ClockSkew = TimeSpan.MaxValue
                };
            });

            return services;
        }
    }
}
