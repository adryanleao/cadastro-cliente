using Microsoft.OpenApi.Models;

namespace Cliente.Services.Api.Configurations;

public static class SwaggerConfig
{
    public static void AddSwaggerConfiguration(this IServiceCollection services)
    {
        if (services == null) throw new ArgumentNullException(nameof(services));

        services.AddSwaggerGen(s =>
        {
            s.SwaggerDoc("v1", new OpenApiInfo
            {
                Version = "v1",
                Title = "Projeto Cadastro-Cliente",
                Description = "Cadastro-Cliente API Swagger",
                Contact = new OpenApiContact { Name = "Adryan Leão", Email = "adryanleao@gmail.com", Url = new Uri("https://www.linkedin.com/in/adryanleao/") },
                License = new OpenApiLicense { Name = "MIT", Url = new Uri("https://github.com/adryanleao/cadastro-cliente") }
            });
        });
    }

    public static void UseSwaggerSetup(this IApplicationBuilder app)
    {
        if (app == null) throw new ArgumentNullException(nameof(app));

        app.UseSwagger();
        app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "v1");
        });
    }

}
