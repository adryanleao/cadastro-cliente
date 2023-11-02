using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Cliente.Infra.Data;

public class ClienteContextFactory : IDesignTimeDbContextFactory<ClienteContext>
{
    //dotnet ef migrations add Initial --context ClienteContext --project ./Cliente.Infra.Data --output-dir Migrations/Cliente
    public ClienteContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<ClienteContext>();
        optionsBuilder.UseSqlServer("");

        return new ClienteContext(optionsBuilder.Options);
    }
}