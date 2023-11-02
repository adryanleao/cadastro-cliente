using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace Cliente.Infra.Data.Migrations;

public class EventStoreSqlContextFactory : IDesignTimeDbContextFactory<EventStoreSqlContext>
{
    //dotnet ef migrations add Initial --context EventStoreSqlContext --project ./Cliente.Infra.Data --output-dir Migrations/EventStore
    public EventStoreSqlContext CreateDbContext(string[] args)
    {
        var optionsBuilder = new DbContextOptionsBuilder<EventStoreSqlContext>();
        optionsBuilder.UseSqlServer("");

        return new EventStoreSqlContext(optionsBuilder.Options);
    }
}