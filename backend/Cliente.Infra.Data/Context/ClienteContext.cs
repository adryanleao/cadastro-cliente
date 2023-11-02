using Cliente.Domain.Core;
using Cliente.Domain.Core.Events;
using Cliente.Infra.Data.Mappings;
using FluentValidation.Results;
using Microsoft.EntityFrameworkCore;
using Models = Cliente.Domain.Models;

namespace Cliente.Infra.Data;

public sealed class ClienteContext : DbContext
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
}