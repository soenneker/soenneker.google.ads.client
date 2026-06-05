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
    /// Gets the value.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task containing the result of the operation.</returns>
    ValueTask<GoogleAdsClient> Get(CancellationToken cancellationToken = default);
}