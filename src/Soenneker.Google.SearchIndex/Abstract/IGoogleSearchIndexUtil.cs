using Google.Apis.Indexing.v3.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Google.SearchIndex.Abstract;

/// <summary>
/// A utility library for Google Search index related operations
/// </summary>
public interface IGoogleSearchIndexUtil
{
    /// <summary>
    /// Adds update index.
    /// </summary>
    /// <param name="jobUrl">URL of the job to target.</param>
    /// <param name="action">action to invoke when the operation runs.</param>
    /// <param name="fileName">Name of the target file.</param>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>A task whose result is the requested publish URL Notification Response.</returns>
    ValueTask<PublishUrlNotificationResponse> AddUpdateIndex(string jobUrl, string action, string fileName, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets index status.
    /// </summary>
    /// <param name="jobUrl">URL of the job to target.</param>
    /// <param name="fileName">Name of the target file.</param>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>A task whose result is the requested URL Notification Metadata.</returns>
    ValueTask<UrlNotificationMetadata?> GetIndexStatus(string jobUrl, string fileName, CancellationToken cancellationToken = default);
}
