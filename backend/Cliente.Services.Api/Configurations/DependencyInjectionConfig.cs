﻿using Cliente.Infra.CrossCutting.IoC;

namespace Cliente.Services.Api.Configurations;

public static class DependencyInjectionConfig
{
    public static void AddDependencyInjectionConfiguration(this IServiceCollection services)
    {
        if (services == null) throw new ArgumentNullException(nameof(services));

        NativeInjectorBootStrapper.RegisterServices(services);
    }

    public static void ApplyMigrateDB(this IApplicationBuilder app)
    {
        NativeInjectorBootStrapper.ApplyMigrateDB(app);
    }
}
