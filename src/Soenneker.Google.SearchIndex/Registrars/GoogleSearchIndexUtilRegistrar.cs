using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Google.IndexingService.Registrars;
using Soenneker.Google.SearchIndex.Abstract;

namespace Soenneker.Google.SearchIndex.Registrars;

/// <summary>
/// Registers scoped or singleton URL-notification operations over a shared indexing client provider.
/// </summary>
public static class GoogleSearchIndexUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="IGoogleSearchIndexUtil"/> as a singleton service. <para/>
    /// </summary>
    /// <param name="services">Service collection that receives the registration.</param>
    /// <returns>The same service collection, so additional registrations can be chained.</returns>
    public static IServiceCollection AddGoogleSearchIndexUtilAsSingleton(this IServiceCollection services)
    {
        services.AddGoogleIndexingServiceUtilAsSingleton();
        services.TryAddSingleton<IGoogleSearchIndexUtil, GoogleSearchIndexUtil>();
        return services;
    }

    /// <summary>
    /// Adds <see cref="IGoogleSearchIndexUtil"/> as a scoped service. <para/>
    /// </summary>
    /// <param name="services">Service collection that receives the registration.</param>
    /// <returns>The same service collection, so additional registrations can be chained.</returns>
    public static IServiceCollection AddGoogleSearchIndexUtilAsScoped(this IServiceCollection services)
    {
        services.AddGoogleIndexingServiceUtilAsSingleton();
        services.TryAddScoped<IGoogleSearchIndexUtil, GoogleSearchIndexUtil>();
        return services;
    }
}
