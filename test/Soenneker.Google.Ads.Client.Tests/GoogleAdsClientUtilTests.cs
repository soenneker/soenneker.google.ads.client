using Soenneker.Google.Ads.Client.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Google.Ads.Client.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public class GoogleAdsClientUtilTests : HostedUnitTest
{
    private readonly IGoogleAdsClientUtil _util;

    public GoogleAdsClientUtilTests(Host host) : base(host)
    {
        _util = Resolve<IGoogleAdsClientUtil>(true);
    }

    [Test]
    public void Default()
    {

    }
}
