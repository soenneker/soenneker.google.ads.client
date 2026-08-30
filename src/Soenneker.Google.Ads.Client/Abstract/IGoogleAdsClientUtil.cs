using Google.Ads.GoogleAds.Lib;
using System;
using System.Threading.Tasks;
using System.Threading;

namespace Soenneker.Google.Ads.Client.Abstract;

/// <summary>
/// Provides one lazily initialized, thread-safe <see cref="GoogleAdsClient"/> for the lifetime of the provider.
/// </summary>
public interface IGoogleAdsClientUtil : IAsyncDisposable, IDisposable
{
    /// <summary>
    /// Gets or creates the configured Google Ads client.
    /// </summary>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>The shared client owned by this provider.</returns>
    ValueTask<GoogleAdsClient> Get(CancellationToken cancellationToken = default);
}
