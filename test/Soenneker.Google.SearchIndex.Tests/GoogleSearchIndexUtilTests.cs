using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Soenneker.Google.IndexingService.Abstract;
using Soenneker.Google.SearchIndex.Abstract;
using Soenneker.Google.SearchIndex.Registrars;
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

    [Test]
    public async Task Scoped_registration_keeps_indexing_client_provider_singleton()
    {
        var services = new ServiceCollection();

        services.AddGoogleSearchIndexUtilAsScoped();

        ServiceDescriptor clientProvider = services.Single(descriptor => descriptor.ServiceType == typeof(IGoogleIndexingServiceUtil));
        ServiceDescriptor searchUtil = services.Single(descriptor => descriptor.ServiceType == typeof(IGoogleSearchIndexUtil));

        await Assert.That(clientProvider.Lifetime).IsEqualTo(ServiceLifetime.Singleton);
        await Assert.That(searchUtil.Lifetime).IsEqualTo(ServiceLifetime.Scoped);
    }
}
