[![](https://img.shields.io/nuget/v/soenneker.google.searchindex.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.google.searchindex/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.google.searchindex/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.google.searchindex/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.google.searchindex.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.google.searchindex/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.google.searchindex/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.google.searchindex/actions/workflows/codeql.yml)

# Soenneker.Google.SearchIndex

Scoped URL-notification operations over a shared Google Indexing API client provider.

## Install

```bash
dotnet add package Soenneker.Google.SearchIndex
```

## Credential file

Place a Google service-account JSON file beneath `LocalResources` in the application output. The service account must be authorized for the target site.

```xml
<Content Include="LocalResources\google-indexing.json"
         CopyToOutputDirectory="PreserveNewest" />
```

## Register

```csharp
using Soenneker.Google.SearchIndex.Registrars;
using Microsoft.Extensions.DependencyInjection;

services.AddGoogleSearchIndexUtilAsScoped();
```

This intentionally registers `IGoogleSearchIndexUtil` as scoped and `IGoogleIndexingServiceUtil` as singleton. Disposing a scope destroys the short-lived utility while the cached authenticated client remains available to later scopes.

`AddGoogleSearchIndexUtilAsSingleton()` is also available when the operation wrapper itself should be application-wide.

## Publish and inspect a notification

```csharp
PublishUrlNotificationResponse response = await searchIndex.AddUpdateIndex(
    "https://example.com/jobs/software-engineer",
    "URL_UPDATED",
    "google-indexing.json",
    cancellationToken);

UrlNotificationMetadata? metadata = await searchIndex.GetIndexStatus(
    "https://example.com/jobs/software-engineer",
    "google-indexing.json",
    cancellationToken);
```

`GetIndexStatus()` returns notification metadata, not a general Google Search crawl or ranking status. This package does not decide whether a URL is eligible for the Indexing API.

## API at a glance

| API | What it does | Result / important behavior |
| --- | --- | --- |
| `AddUpdateIndex(jobUrl, action, fileName)` | Publishes a URL notification using the named service account. | Returns Google's publish response. |
| `GetIndexStatus(jobUrl, fileName)` | Retrieves the latest notification metadata for a URL. | Returns `null` only when Google responds that no metadata was found. |

Authentication, authorization, quota, transport, and other API failures propagate to the caller. Cancellation is not converted into a missing-status result.
