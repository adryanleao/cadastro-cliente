using Cliente.Infra.Data;
using Microsoft.EntityFrameworkCore;

namespace Cliente.Services.Api.Configurations;

public static class DatabaseConfig
{
    public static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
    {
        if (services == null) throw new ArgumentNullException(nameof(services));
        
        Console.WriteLine(configuration.GetConnectionString("CadastroClienteConnection"));
        services.AddDbContext<ClienteContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("CadastroClienteConnection")));

        services.AddDbContext<EventStoreSqlContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("CadastroClienteConnection")));
    }
}
