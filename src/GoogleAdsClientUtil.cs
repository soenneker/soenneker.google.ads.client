using Google.Ads.GoogleAds.Config;
using Google.Ads.GoogleAds.Lib;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Soenneker.Extensions.Configuration;
using Soenneker.Extensions.ValueTask;
using Soenneker.Google.Ads.Client.Abstract;
using Soenneker.Utils.AsyncSingleton;
using System;
using System.Threading.Tasks;
using System.Threading;

namespace Soenneker.Google.Ads.Client;

/// <inheritdoc cref="IGoogleAdsClientUtil"/>
public class GoogleAdsClientUtil: IGoogleAdsClientUtil
{
    private readonly AsyncSingleton<GoogleAdsClient> _client;

    public GoogleAdsClientUtil(ILogger<GoogleAdsClientUtil> logger, IConfiguration configuration)
    {
        _client = new AsyncSingleton<GoogleAdsClient>((_, _) =>
        {
            logger.LogInformation("Connecting to Google Ads...");

            var config = new GoogleAdsConfig
            {
                DeveloperToken = configuration.GetValueStrict<string>("Google:Ads:DeveloperToken"),
                OAuth2ClientId = configuration.GetValueStrict<string>("Google:Ads:ClientId"),
                OAuth2ClientSecret = configuration.GetValueStrict<string>("Google:Ads:ClientSecret")
            };

            return new GoogleAdsClient(config);
        });
    }

    public ValueTask<GoogleAdsClient> Get(CancellationToken cancellationToken = default)
    {
        return _client.Get(cancellationToken);
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);

        _client.Dispose();
    }

    public async ValueTask DisposeAsync()
    {
        GC.SuppressFinalize(this);

        await _client.DisposeAsync().NoSync();
    }
}
