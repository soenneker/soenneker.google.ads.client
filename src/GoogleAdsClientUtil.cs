using Google.Ads.GoogleAds.Config;
using Google.Ads.GoogleAds.Lib;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Soenneker.Extensions.Configuration;
using Soenneker.Google.Ads.Client.Abstract;
using Soenneker.Utils.AsyncSingleton;
using System.Threading.Tasks;
using System.Threading;

namespace Soenneker.Google.Ads.Client;

/// <inheritdoc cref="IGoogleAdsClientUtil"/>
public sealed class GoogleAdsClientUtil: IGoogleAdsClientUtil
{
    private readonly AsyncSingleton<GoogleAdsClient> _client;
    private readonly ILogger<GoogleAdsClientUtil> _logger;
    private readonly IConfiguration _configuration;

    public GoogleAdsClientUtil(ILogger<GoogleAdsClientUtil> logger, IConfiguration configuration)
    {
        _logger = logger;
        _configuration = configuration;
        _client = new AsyncSingleton<GoogleAdsClient>(CreateClient);
    }

    private GoogleAdsClient CreateClient(CancellationToken _)
    {
        _logger.LogInformation("Connecting to Google Ads...");

        var config = new GoogleAdsConfig
        {
            DeveloperToken = _configuration.GetValueStrict<string>("Google:Ads:DeveloperToken"),
            OAuth2ClientId = _configuration.GetValueStrict<string>("Google:Ads:ClientId"),
            OAuth2ClientSecret = _configuration.GetValueStrict<string>("Google:Ads:ClientSecret")
        };

        return new GoogleAdsClient(config);
    }

    public ValueTask<GoogleAdsClient> Get(CancellationToken cancellationToken = default)
    {
        return _client.Get(cancellationToken);
    }

    public void Dispose()
    {
        _client.Dispose();
    }

    public ValueTask DisposeAsync()
    {
         return _client.DisposeAsync();
    }
}
