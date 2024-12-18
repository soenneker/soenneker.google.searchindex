using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Soenneker.Google.SearchIndex.Abstract;
using Soenneker.Tests.FixturedUnit;
using Xunit;


namespace Soenneker.Google.SearchIndex.Tests;

[Collection("Collection")]
public class GoogleSearchIndexUtilTests : FixturedUnitTest
{
    private readonly IGoogleSearchIndexUtil _util;

    public GoogleSearchIndexUtilTests(Fixture fixture, ITestOutputHelper output) : base(fixture, output)
    {
        _util = Resolve<IGoogleSearchIndexUtil>(true);
    }
}
