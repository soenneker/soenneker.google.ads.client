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
    ValueTask<GoogleAdsClient> Get(CancellationToken cancellationToken = default);
}