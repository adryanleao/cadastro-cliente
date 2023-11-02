using Cliente.Domain.Core;
using Cliente.Domain.Core.Events;
using Cliente.Domain.Interfaces;
using Cliente.Infra.Data.Mappings;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using Models = Cliente.Domain.Models;

namespace Cliente.Infra.Data;

public sealed class ClienteContext : DbContext, IUnitOfWork
{
    private readonly IMediatorHandler _mediatorHandler;
    public DbSet<Models.Cliente> Clientes { get; set; }
    public DbSet<Models.Endereco> Enderecos { get; set; }
    public ClienteContext(
        DbContextOptions<ClienteContext> options,
        IMediatorHandler mediatorHandler) : base(options)
    {
        _mediatorHandler = mediatorHandler;
        ChangeTracker.QueryTrackingBehavior = QueryTrackingBehavior.NoTracking;
        ChangeTracker.AutoDetectChangesEnabled = false;
    }

    public ClienteContext(DbContextOptions<ClienteContext> options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<ValidationResult>();
            modelBuilder.Ignore<Event>();

            foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
                e => e.GetProperties().Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            modelBuilder.ApplyConfiguration(new ClienteMap());
            modelBuilder.ApplyConfiguration(new EnderecoMap());
                        
            base.OnModelCreating(modelBuilder);
        }

    public async Task<bool> Commit()
    {
         await _mediatorHandler.PublishDomainEvents(this).ConfigureAwait(false);
         var success = await SaveChangesAsync() > 0;
         return success;
    }
}

public static class MediatorExtension
    {
        public static async Task PublishDomainEvents<T>(this IMediatorHandler mediator, T ctx) where T : DbContext
        {
            var domainEntities = ctx.ChangeTracker
                .Entries<ModelBase>()
                .Where(x => x.Entity.DomainEvents != null && x.Entity.DomainEvents.Any());

            var domainEvents = domainEntities
                .SelectMany(x => x.Entity.DomainEvents)
                .ToList();

            domainEntities.ToList()
                .ForEach(entity => entity.Entity.ClearDomainEvents());

            var tasks = domainEvents
                .Select(async (domainEvent) => {
                    await mediator.RaiseEvent(domainEvent);
                });

            await Task.WhenAll(tasks);
        }
    }