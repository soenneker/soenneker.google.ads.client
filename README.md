[![](https://img.shields.io/nuget/v/soenneker.google.ads.client.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.google.ads.client/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.google.ads.client/publish-package.yml?style=for-the-badge)](https://github.com/soenneker/soenneker.google.ads.client/actions/workflows/publish-package.yml)
[![](https://img.shields.io/nuget/dt/soenneker.google.ads.client.svg?style=for-the-badge)](https://www.nuget.org/packages/soenneker.google.ads.client/)
[![](https://img.shields.io/github/actions/workflow/status/soenneker/soenneker.google.ads.client/codeql.yml?label=CodeQL&style=for-the-badge)](https://github.com/soenneker/soenneker.google.ads.client/actions/workflows/codeql.yml)

# Soenneker.Google.Ads.Client

A lazy, thread-safe `GoogleAdsClient` provider with dependency-injection registration and deterministic disposal.

## Install

```bash
dotnet add package Soenneker.Google.Ads.Client
```

## Configuration

```json
{
  "Google": {
    "Ads": {
      "DeveloperToken": "<developer token>",
      "ClientId": "<OAuth client ID>",
      "ClientSecret": "<OAuth client secret>"
    }
  }
}
```

The values are read when `Get()` first creates the client, not during service registration.

## Registration

```csharp
using Soenneker.Google.Ads.Client.Registrars;
using Microsoft.Extensions.DependencyInjection;

services.AddGoogleAdsClientUtilAsSingleton();
```

Singleton registration is the normal choice for this package: callers and scoped utilities can share the long-lived Google Ads client while their own scopes are disposed independently.

`AddGoogleAdsClientUtilAsScoped()` is available when a separate client really is required per scope; disposing the scope then disposes that scope's provider and client.

## Usage

```csharp
public sealed class CampaignReader
{
    private readonly IGoogleAdsClientUtil _clientUtil;

    public CampaignReader(IGoogleAdsClientUtil clientUtil)
    {
        _clientUtil = clientUtil;
    }

    public async ValueTask<GoogleAdsClient> GetClient(CancellationToken cancellationToken)
    {
        return await _clientUtil.Get(cancellationToken);
    }
}
```

Every `Get()` call on the same provider returns the same lazily created `GoogleAdsClient`. Concurrent first calls share one initialization.

## API at a glance

| API | What it does | Result / important behavior |
| --- | --- | --- |
| `Get(cancellationToken)` | Gets or creates the configured client. | Reuses one client for the lifetime of the provider. |
| `AddGoogleAdsClientUtilAsSingleton()` | Registers one provider for the application. | Recommended for sharing the client across scoped consumers. |
| `AddGoogleAdsClientUtilAsScoped()` | Registers one provider per DI scope. | Each scope creates and owns a separate client. |

## Practical notes

- Let the DI container dispose registered instances. If you construct `GoogleAdsClientUtil` yourself, dispose it asynchronously or synchronously when finished.
- Cancellation affects pending lazy initialization. It does not cancel operations performed later through the returned Google Ads client.
