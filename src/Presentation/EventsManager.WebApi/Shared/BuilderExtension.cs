using EventsManager.Application;
using EventsManager.Application.Handlers;
using EventsManager.Persistence.Context;
using EventsManager.WebApi.Handlers;
using EventsManager.WebApi.Services;
using Fina.Api;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

namespace EventsManager.WebApi.Shared;

public static class BuilderExtension
{
    public static void AddConfigurations(this WebApplicationBuilder builder)
    {
        ApiConfiguration.ConnectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? string.Empty;

        Configuration.BackendUrl = builder.Configuration.GetValue<string>("BackendUrl") ?? string.Empty;
        Configuration.FrontendUrl = builder.Configuration.GetValue<string>("FrontendUrl") ?? string.Empty;
    }

    public static void AddDocumentation(this WebApplicationBuilder builder)
    {
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen(x =>
        {
            x.SwaggerDoc("v1", new OpenApiInfo
            {
                Title = "Events Manager API",
                Version = "v1",
                Description = "API para gerenciamento de eventos",
                Contact = new OpenApiContact
                {
                    Name = "Pedro Lucas",
                    Email = "pedrogmobile2@gmail.com",
                    Url = new Uri("https://github.com/Pedro-Lucas-OKB")
                }
            });

            x.CustomSchemaIds(n => n.FullName);
        });
    }

    public static void AddDataContexts(this WebApplicationBuilder builder)
    {
        builder
            .Services
            .AddDbContext<AppDbContext>(
                options =>
                {
                    options.UseSqlServer(ApiConfiguration.ConnectionString);
                });
    }

    public static void AddCrossOrigin(this WebApplicationBuilder builder)
    {
        builder.Services.AddCors(
            options => options.AddPolicy(
                ApiConfiguration.CorsPolicyName,
                policy => policy
                    .WithOrigins([
                        Configuration.BackendUrl,
                        Configuration.FrontendUrl
                    ])
                    .AllowAnyMethod()
                    .AllowAnyHeader()
                    .AllowCredentials()
            ));
    }

    public static void AddServices(this WebApplicationBuilder builder)
    {
        builder
            .Services
            .AddTransient<IParticipantHandler, ParticipantHandler>();

        builder
            .Services
            .AddTransient<TokenService>();
    }
}
