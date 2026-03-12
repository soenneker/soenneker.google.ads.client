using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Soenneker.Google.Ads.Client.Abstract;

namespace Soenneker.Google.Ads.Client.Registrars;

/// <summary>
/// An async thread-safe singleton for the Google Ads client
/// </summary>
public static class GoogleAdsClientUtilRegistrar
{
    /// <summary>
    /// Adds <see cref="IGoogleAdsClientUtil"/> as a singleton service. <para/>
    /// </summary>
    public static IServiceCollection AddGoogleAdsClientUtilAsSingleton(this IServiceCollection services)
    {
        services.TryAddSingleton<IGoogleAdsClientUtil, GoogleAdsClientUtil>();

        return services;
    }

    /// <summary>
    /// Adds <see cref="IGoogleAdsClientUtil"/> as a scoped service. <para/>
    /// </summary>
    public static IServiceCollection AddGoogleAdsClientUtilAsScoped(this IServiceCollection services)
    {
        services.TryAddScoped<IGoogleAdsClientUtil, GoogleAdsClientUtil>();

        return services;
    }
}
