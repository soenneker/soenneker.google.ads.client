using Soenneker.Google.Ads.Client.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;

namespace Soenneker.Google.Ads.Client.Tests;

[Collection("Collection")]
public class GoogleAdsClientUtilTests : FixturedUnitTest
{
    private readonly IGoogleAdsClientUtil _util;

    public GoogleAdsClientUtilTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _util = Resolve<IGoogleAdsClientUtil>(true);
    }

    [Fact]
    public void Default()
    {

    }
}
