using Google.Ads.GoogleAds.Lib;
using System;
using System.Threading.Tasks;
using System.Threading;

namespace Soenneker.Google.Ads.Client.Abstract;

/// <summary>
/// An async thread-safe singleton for the Google Ads client
/// </summary>
public interface IGoogleAdsClientUtil : IAsyncDisposable, IDisposable
{
    /// <summary>
    /// Returns the configured google Ads Client used by the google ads client.
    /// </summary>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>A task whose result is the requested google Ads Client.</returns>
    ValueTask<GoogleAdsClient> Get(CancellationToken cancellationToken = default);
}
