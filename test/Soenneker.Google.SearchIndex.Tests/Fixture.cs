using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;
using Soenneker.Fixtures.Unit;
using Soenneker.Google.SearchIndex.Registrars;
using Soenneker.Utils.Test;

namespace Soenneker.Google.SearchIndex.Tests;

public class Fixture : UnitFixture
{
    public override System.Threading.Tasks.Task InitializeAsync()
    {
        SetupIoC(Services);

        return base.InitializeAsync();
    }

    private static void SetupIoC(IServiceCollection services)
    {
        services.AddLogging(builder => { builder.AddSerilog(dispose: true); });

        IConfiguration config = TestUtil.BuildConfig();
        services.AddSingleton(config);

        services.AddGoogleSearchIndexUtilAsSingleton();
    }
}