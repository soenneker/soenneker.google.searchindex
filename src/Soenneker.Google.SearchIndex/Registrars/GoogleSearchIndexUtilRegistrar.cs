using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Google.IndexingService.Registrars;
using Soenneker.Google.SearchIndex.Abstract;

namespace Soenneker.Google.SearchIndex.Registrars;

/// <summary>
/// A utility library for Google Search index related operations
/// </summary>
public static class GoogleSearchIndexUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="IGoogleSearchIndexUtil"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddGoogleSearchIndexUtilAsSingleton(this IServiceCollection services)
    {
        services.AddGoogleIndexingServiceUtilAsSingleton();
        services.TryAddSingleton<IGoogleSearchIndexUtil, GoogleSearchIndexUtil>();
        return services;
    }

    /// <summary>
    /// Adds <see cref="IGoogleSearchIndexUtil"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddGoogleSearchIndexUtilAsScoped(this IServiceCollection services)
    {
        services.AddGoogleIndexingServiceUtilAsScoped();
        services.TryAddScoped<IGoogleSearchIndexUtil, GoogleSearchIndexUtil>();
        return services;
    }
}