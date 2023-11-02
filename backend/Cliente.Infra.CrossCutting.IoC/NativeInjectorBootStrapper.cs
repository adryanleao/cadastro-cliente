using Cliente.Domain.Core;
using Cliente.Domain.Core.Events;
using Cliente.Infra.CrossCutting.Bus;
using Cliente.Infra.Data;
using Cliente.Infra.Data.EventSourcing;
using Cliente.Infra.Data.Repository.EventSourcing;
using Microsoft.Extensions.DependencyInjection;

namespace Cliente.Infra.CrossCutting.IoC;

public static class NativeInjectorBootStrapper
{
    public static void RegisterServices(IServiceCollection services)
    {
        // Domain Bus (Mediator)
        services.AddScoped<IMediatorHandler, InMemoryBus>();

        // Application
        //services.AddScoped<IClienteAppService, ClienteAppService>();

        // Domain - Events
        //services.AddScoped<INotificationHandler<ClienteRegisteredEvent>, ClienteEventHandler>();
        //services.AddScoped<INotificationHandler<ClienteUpdatedEvent>, ClienteEventHandler>();
        //services.AddScoped<INotificationHandler<ClienteRemovedEvent>, ClienteEventHandler>();

        // Domain - Commands
        //services.AddScoped<IRequestHandler<RegisterNewClienteCommand, ValidationResult>, ClienteCommandHandler>();
        //services.AddScoped<IRequestHandler<UpdateClienteCommand, ValidationResult>, ClienteCommandHandler>();
        //services.AddScoped<IRequestHandler<RemoveClienteCommand, ValidationResult>, ClienteCommandHandler>();

        // Infra - Data
        //services.AddScoped<IClienteRepository, ClienteRepository>();
        //services.AddScoped<ClienteContext>();

        // Infra - Data EventSourcing
        services.AddScoped<IEventStoreRepository, EventStoreRepository>();
        services.AddScoped<IEventStore, SqlEventStore>();
        services.AddScoped<EventStoreSqlContext>();
    }
}