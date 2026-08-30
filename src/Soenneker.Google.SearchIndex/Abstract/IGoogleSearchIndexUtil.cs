using Google.Apis.Indexing.v3.Data;
using System.Threading;
using System.Threading.Tasks;

namespace Soenneker.Google.SearchIndex.Abstract;

/// <summary>
/// Publishes Google Indexing API URL notifications and retrieves their metadata.
/// </summary>
public interface IGoogleSearchIndexUtil
{
    /// <summary>
    /// Publishes an indexing notification for a URL.
    /// </summary>
    /// <param name="jobUrl">The absolute URL to notify Google about.</param>
    /// <param name="action">The Indexing API notification type, such as <c>URL_UPDATED</c> or <c>URL_DELETED</c>.</param>
    /// <param name="fileName">The service-account filename relative to <c>LocalResources</c>.</param>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>Google's publish response.</returns>
    ValueTask<PublishUrlNotificationResponse> AddUpdateIndex(string jobUrl, string action, string fileName, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets Google's most recent notification metadata for a URL.
    /// </summary>
    /// <param name="jobUrl">URL of the job to target.</param>
    /// <param name="fileName">Name of the target file.</param>
    /// <param name="cancellationToken">Token used to cancel the operation.</param>
    /// <returns>The notification metadata, or <see langword="null"/> when Google reports no metadata for the URL.</returns>
    ValueTask<UrlNotificationMetadata?> GetIndexStatus(string jobUrl, string fileName, CancellationToken cancellationToken = default);
}
