[![](https://img.shields.io/nuget/v/soenneker.google.searchindex.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.google.searchindex/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.google.searchindex/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.google.searchindex/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.google.searchindex.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.google.searchindex/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.google.searchindex/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.google.searchindex/actions/workflows/codeql.yml)

# Soenneker.Google.SearchIndex

A utility library for Google Search index related operations.

## Install

```bash
dotnet add package Soenneker.Google.SearchIndex
```

## Quick start

```csharp
using Soenneker.Google.SearchIndex.Registrars;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
var result = services.AddGoogleSearchIndexUtilAsSingleton();
```

Adds `IGoogleSearchIndexUtil` as a singleton service.

## What you get

- `IGoogleSearchIndexUtil` — A utility library for Google Search index related operations.
- `GoogleSearchIndexUtilRegistrar` — A utility library for Google Search index related operations.

## API at a glance

| API | What it does | Result / important behavior |
| --- | --- | --- |
| `GoogleSearchIndexUtilRegistrar.AddGoogleSearchIndexUtilAsSingleton(services)` | Adds `IGoogleSearchIndexUtil` as a singleton service. | The same service collection, so additional registrations can be chained. |
| `GoogleSearchIndexUtilRegistrar.AddGoogleSearchIndexUtilAsScoped(services)` | Adds `IGoogleSearchIndexUtil` as a scoped service. | The same service collection, so additional registrations can be chained. |
