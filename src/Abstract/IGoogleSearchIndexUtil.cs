using Google.Apis.Indexing.v3.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Google.SearchIndex.Abstract;

/// <summary>
/// A utility library for Google Search index related operations
/// </summary>
public interface IGoogleSearchIndexUtil
{
    ValueTask<PublishUrlNotificationResponse> AddUpdateIndex(string jobUrl, string action, string fileName, CancellationToken cancellationToken = default);

    ValueTask<UrlNotificationMetadata?> GetIndexStatus(string jobUrl, string fileName, CancellationToken cancellationToken = default);
}
