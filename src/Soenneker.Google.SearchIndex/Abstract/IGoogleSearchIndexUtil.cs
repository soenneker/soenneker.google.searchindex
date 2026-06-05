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
    /// <param name="jobUrl">The job url.</param>
    /// <param name="action">The action.</param>
    /// <param name="fileName">The file name.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task containing the result of the operation.</returns>
    ValueTask<PublishUrlNotificationResponse> AddUpdateIndex(string jobUrl, string action, string fileName, CancellationToken cancellationToken = default);

    /// <summary>
    /// Gets index status.
    /// </summary>
    /// <param name="jobUrl">The job url.</param>
    /// <param name="fileName">The file name.</param>
    /// <param name="cancellationToken">The cancellation token.</param>
    /// <returns>A task containing the result of the operation.</returns>
    ValueTask<UrlNotificationMetadata?> GetIndexStatus(string jobUrl, string fileName, CancellationToken cancellationToken = default);
}
