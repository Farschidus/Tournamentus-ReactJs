using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Tournamentus.Core;
using Tournamentus.Core.Api;
using Tournamentus.Core.Data;
using Tournamentus.Core.Infrastructure;
using StructureMap;
using StructureMap.Pipeline;

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
            For<IMediator>().Use<Mediator>();
            For(typeof(IPipelineBehavior<,>)).Add(typeof(ValidationPipeline<,>));

            // Application Settings
            For<AppSettings>().Use(settings).LifecycleIs<SingletonLifecycle>();

            // database context
            For<TournamentusDb>().Use(() => new TournamentusDb(settings.ConnectionStrings.TournamentusDb)).LifecycleIs<TransientLifecycle>();

            // principal provider
            For<IHttpContextAccessor>().Use<HttpContextAccessor>().LifecycleIs<SingletonLifecycle>();
            //For<TournamentusPrincipal>().Use(ctx => ctx.GetInstance<PrincipalProvider>().Current()).LifecycleIs<TransientLifecycle>();

            // HttpClient used for Eseye API call
            For<IHttpHandler>().Use<HttpClientHandler>();

            // localization in Tournamentus.Core
            For<ILoggerFactory>().Use<LoggerFactory>();
            For(typeof(IOptions<>)).Add(typeof(OptionsManager<>)).LifecycleIs<SingletonLifecycle>();
            For(typeof(IOptionsFactory<>)).Add(typeof(OptionsFactory<>)).LifecycleIs<TransientLifecycle>();
        }
    }
}
