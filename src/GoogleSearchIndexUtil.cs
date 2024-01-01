using Soenneker.Google.SearchIndex.Abstract;
using System.Threading.Tasks;
using System;
using Google.Apis.Indexing.v3;
using Google.Apis.Indexing.v3.Data;
using Microsoft.Extensions.Logging;
using Soenneker.Google.IndexingService.Abstract;
using Soenneker.Utils.Method;

namespace Soenneker.Google.SearchIndex;

/// <inheritdoc cref="IGoogleSearchIndexUtil"/>
public class GoogleSearchIndexUtil : IGoogleSearchIndexUtil
{
    private readonly IGoogleIndexingServiceUtil _googleIndexingServiceUtil;
    private readonly ILogger<GoogleSearchIndexUtil> _logger;

    public GoogleSearchIndexUtil(IGoogleIndexingServiceUtil googleIndexingServiceUtil, ILogger<GoogleSearchIndexUtil> logger)
    {
        _googleIndexingServiceUtil = googleIndexingServiceUtil;
        _logger = logger;
    }

    public async ValueTask<PublishUrlNotificationResponse> AddUpdateIndex(string jobUrl, string action, string fileName)
    {
        global::Google.Apis.Indexing.v3.IndexingService service = await _googleIndexingServiceUtil.Get(fileName);

        _logger.LogInformation("{method} for URI: {uri} ...", MethodUtil.Get(), jobUrl);

        var requestBody = new UrlNotification
        {
            Url = jobUrl,
            Type = action
        };

        var publishRequest = new UrlNotificationsResource.PublishRequest(service, requestBody);

        PublishUrlNotificationResponse? result = await publishRequest.ExecuteAsync();
        return result;
    }

    public async ValueTask<UrlNotificationMetadata?> GetIndexStatus(string jobUrl, string fileName)
    {
        global::Google.Apis.Indexing.v3.IndexingService service = await _googleIndexingServiceUtil.Get(fileName);

        _logger.LogInformation("{method} for URI: {uri} ...", MethodUtil.Get(), jobUrl);

        var metaDataRequest = new UrlNotificationsResource.GetMetadataRequest(service)
        {
            Url = jobUrl
        };

        try
        {
            UrlNotificationMetadata? result = await metaDataRequest.ExecuteAsync();
            return result;
        }
        catch (Exception e)
        {
            _logger.LogError(e, "Error retrieving metadata status, we will assume negative index");
            return null;
        }
    }
}