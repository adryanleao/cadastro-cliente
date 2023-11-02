using AutoMapper.Configuration.Annotations;
using Cliente.Application.Interfaces;
using Cliente.Application.Services;
using Cliente.Domain.Commands;
using Cliente.Domain.Commands.CommandHandlers;
using Cliente.Domain.Core;
using Cliente.Domain.Core.Events;
using Cliente.Domain.Core.Notifications;
using Cliente.Domain.Events;
using Cliente.Domain.Interfaces;
using Cliente.Infra.CrossCutting.Bus;
using Cliente.Infra.Data;
using Cliente.Infra.Data.EventSourcing;
using Cliente.Infra.Data.Repository;
using Cliente.Infra.Data.Repository.EventSourcing;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using FluentValidation.Results;
using Cliente.Domain.Models;
using Cliente.Infra.Rest.Repository;

namespace Cliente.Infra.CrossCutting.IoC;

public static class NativeInjectorBootStrapper
{
    public static void RegisterServices(IServiceCollection services)
    {
        // ASP.NET HttpContext dependency
        services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
        // Domain Bus (Mediator)
        services.AddScoped<IMediatorHandler, InMemoryBus>();

        // Application
        services.AddScoped<IClienteAppService, ClienteAppService>();
        services.AddScoped<IEnderecoAppService, EnderecoAppService>();

        // Domain - Events
        services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
        services.AddScoped<INotificationHandler<ClienteRegistradoEvent>, ClienteEventHandler>();
        services.AddScoped<INotificationHandler<ClienteRemovidoEvent>, ClienteEventHandler>();
        services.AddScoped<INotificationHandler<ClienteAtualizadoEvent>, ClienteEventHandler>();

        // Domain - Commands
        services.AddScoped<IRequestHandler<RegistrarClienteCommand, ValidationResult>, ClienteCommandHandler>();
        //services.AddScoped<IRequestHandler<AtualizarClienteCommand>, ClienteCommandHandler>();
        //services.AddScoped<IRequestHandler<RemoverClienteCommand>, ClienteCommandHandler>();

        // Infra - Data
        services.AddScoped<IClienteRepository, ClienteRepository>();
        services.AddScoped<ClienteContext>();

        // Infra - Data EventSourcing
        services.AddScoped<IEventStoreRepository, EventStoreRepository>();
        services.AddScoped<IEventStore, SqlEventStore>();
        services.AddScoped<EventStoreSqlContext>();

        // Infra - Rest
        services.AddScoped<IEnderecoRepository, EnderecoRepository>();
    }

    public static void ApplyMigrateDB(this IApplicationBuilder app)
    {
        var scope = app.ApplicationServices.CreateScope();
        var dbContextCliente = scope.ServiceProvider.GetService<ClienteContext>();
        var dbContextEventStore = scope.ServiceProvider.GetService<EventStoreSqlContext>();


        if (!dbContextCliente.Database.EnsureCreated())
            dbContextCliente.Database.Migrate();

        if (!dbContextEventStore.Database.EnsureCreated())
            dbContextEventStore.Database.Migrate();
    }
}