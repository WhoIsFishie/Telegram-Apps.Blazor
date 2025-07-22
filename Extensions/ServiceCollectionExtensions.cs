using Microsoft.Extensions.DependencyInjection;
using TelegramApps.Blazor.Services;

namespace TelegramApps.Blazor.Extensions;

public static class ServiceCollectionExtensions
{
    /// <summary>
    /// Adds Telegram WebApp services to the dependency injection container.
    /// This method supports both Blazor Server and Blazor WebAssembly applications.
    /// </summary>
    /// <param name="services">The service collection to add services to</param>
    /// <returns>The service collection for method chaining</returns>
    public static IServiceCollection AddTelegramWebApp(this IServiceCollection services)
    {
        services.AddScoped<ITelegramWebAppService, TelegramWebAppService>();
        return services;
    }

    /// <summary>
    /// Adds Telegram WebApp services to the dependency injection container with custom configuration.
    /// </summary>
    /// <param name="services">The service collection to add services to</param>
    /// <param name="configure">Configuration action for TelegramWebApp options</param>
    /// <returns>The service collection for method chaining</returns>
    public static IServiceCollection AddTelegramWebApp(this IServiceCollection services, Action<TelegramWebAppOptions> configure)
    {
        services.Configure(configure);
        services.AddScoped<ITelegramWebAppService, TelegramWebAppService>();
        return services;
    }
}

/// <summary>
/// Configuration options for Telegram WebApp integration
/// </summary>
public class TelegramWebAppOptions
{
    /// <summary>
    /// Whether to automatically include the Telegram WebApp script.
    /// Default is true.
    /// </summary>
    public bool IncludeScript { get; set; } = true;

    /// <summary>
    /// Custom script URL for Telegram WebApp library.
    /// Default is the official Telegram CDN URL.
    /// </summary>
    public string ScriptUrl { get; set; } = "https://telegram.org/js/telegram-web-app.js";

    /// <summary>
    /// Whether to enable debug logging for Telegram WebApp interactions.
    /// Default is false.
    /// </summary>
    public bool EnableDebugLogging { get; set; } = false;

    /// <summary>
    /// Timeout in milliseconds for JavaScript interop calls.
    /// Default is 5000ms (5 seconds).
    /// </summary>
    public int InteropTimeoutMs { get; set; } = 5000;
}