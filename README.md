[![](https://img.shields.io/nuget/v/soenneker.google.ads.client.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.google.ads.client/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.google.ads.client/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.google.ads.client/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.google.ads.client.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.google.ads.client/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.google.ads.client/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.google.ads.client/actions/workflows/codeql.yml)

# Soenneker.Google.Ads.Client

An async thread-safe singleton for the Google Ads client.

## Install

```bash
dotnet add package Soenneker.Google.Ads.Client
```

## Quick start

```csharp
using Soenneker.Google.Ads.Client.Registrars;
using Microsoft.Extensions.DependencyInjection;

var services = new ServiceCollection();
var result = services.AddGoogleAdsClientUtilAsSingleton();
```

Adds `IGoogleAdsClientUtil` as a singleton service.

## What you get

- `IGoogleAdsClientUtil` — An async thread-safe singleton for the Google Ads client.
- `GoogleAdsClientUtilRegistrar` — An async thread-safe singleton for the Google Ads client.

## API at a glance

| API | What it does | Result / important behavior |
| --- | --- | --- |
| `GoogleAdsClientUtilRegistrar.AddGoogleAdsClientUtilAsSingleton(services)` | Adds `IGoogleAdsClientUtil` as a singleton service. | The same service collection, so additional registrations can be chained. |
| `GoogleAdsClientUtilRegistrar.AddGoogleAdsClientUtilAsScoped(services)` | Adds `IGoogleAdsClientUtil` as a scoped service. | The same service collection, so additional registrations can be chained. |

## Practical notes

- Reuse the registered client instead of constructing one per operation.
- Calls that return a cached or singleton value reuse the same instance until the owning service is disposed.
- Dispose instances you own when their scope ends so held resources can be released.
