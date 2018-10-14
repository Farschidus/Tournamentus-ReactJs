using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using StructureMap;
using StructureMap.Pipeline;
using Tournamentus.Api.Security;
using Tournamentus.Core;
using Tournamentus.Core.Authentication;
using Tournamentus.Core.Model;

namespace Tournamentus.Api.Infrastructure
{
    public class ApiRegistry : Registry
    {
        public ApiRegistry(AppSettings settings)
        {
            Scan(scanner =>
            {
                scanner.AssembliesAndExecutablesFromApplicationBaseDirectory(assembly => assembly.FullName.StartsWith("Tournamentus"));
                scanner.WithDefaultConventions();
                scanner.TheCallingAssembly();
                scanner.LookForRegistries();
                scanner.AddAllTypesOf(typeof(ITournamentusRequest<>));
                scanner.AddAllTypesOf(typeof(ITournamentusRequestHandler<,>));
                scanner.AddAllTypesOf(typeof(ITournamentusAsyncRequestHandler<,>));
                scanner.AddAllTypesOf(typeof(ITournamentusResponse));
                scanner.AddAllTypesOf(typeof(ITournamentusResponse<>));
                scanner.AddAllTypesOf(typeof(IValidator<>));
            });

            For<SingleInstanceFactory>().Use<SingleInstanceFactory>(ctx => t => ctx.GetInstance(t));
            For<MultiInstanceFactory>().Use<MultiInstanceFactory>(ctx => t => ctx.GetAllInstances(t));

            // mediator and its pipeline
            For<IMediator>().Use<Mediator>().LifecycleIs<TransientLifecycle>();
            For(typeof(IPipelineBehavior<,>)).Add(typeof(ValidationPipeline<,>));


            // Application Settings
            For<AppSettings>().Use(settings).Singleton();

            // database context
            var option = new DbContextOptionsBuilder();
            var dbContextOptions = option.UseSqlServer(settings.ConnectionStrings.TournamentusDb).Options;
            For<TournamentusDb>().Use(t => new TournamentusDb(dbContextOptions)).LifecycleIs<TransientLifecycle>();

            // principal provider
            For<IHttpContextAccessor>().Use<HttpContextAccessor>().LifecycleIs<SingletonLifecycle>();
            For<TournamentusPrincipal>().Use(ctx => ctx.GetInstance<PrincipalProvider>().Current()).Transient();

            // authorization service
            //For<IAuthorizationHandler>().Use<SiteAccess.Handler>().LifecycleIs<TransientLifecycle>();

            // HttpClient used for External API calling integration
            //For<IHttpHandler>().Use<HttpClientHandler>();

            // localization in Tournamentus.Core
            For<ILoggerFactory>().Use<LoggerFactory>();
            //For(typeof(IOptions<>)).Add(typeof(OptionsManager<>)).LifecycleIs<SingletonLifecycle>();
            //For(typeof(IOptionsFactory<>)).Add(typeof(OptionsFactory<>)).LifecycleIs<TransientLifecycle>();
            //For<IStringLocalizerFactory>().Use<ResourceManagerStringLocalizerFactory>().LifecycleIs<SingletonLifecycle>();
            //For(typeof(IStringLocalizer<>)).Add(typeof(StringLocalizer<>)).LifecycleIs<TransientLifecycle>();
        }
    }
}