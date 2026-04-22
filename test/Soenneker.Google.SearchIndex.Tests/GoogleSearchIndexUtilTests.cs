using Soenneker.Google.SearchIndex.Abstract;
using Soenneker.Tests.HostedUnit;

namespace Soenneker.Google.SearchIndex.Tests;

[ClassDataSource<Host>(Shared = SharedType.PerTestSession)]
public class GoogleSearchIndexUtilTests : HostedUnitTest
{
    private readonly IGoogleSearchIndexUtil _util;

    public GoogleSearchIndexUtilTests(Host host) : base(host)
    {
        _util = Resolve<IGoogleSearchIndexUtil>(true);
    }

    [Test]
    public void Default()
    {

    }
}
