using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Nutra.ServiceDefaults;

public static class Extensions
{
    public static void AddServiceDefaults(this WebApplicationBuilder builder)
    {
        // Placeholder for telemetry, health checks, etc.
        builder.Services.AddHealthChecks();
    }

    public static void MapDefaultEndpoints(this WebApplication app)
    {
        app.MapHealthChecks("/health");
    }
}


