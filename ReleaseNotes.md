## AQUARIUS.SDK Release Notes

This page highlights some changes in the SDK.

Not all changes will be listed, but you can always [compare by version tags](https://github.com/AquaticInformatics/aquarius-sdk-net/compare/v17.2.21...v17.2.25) to see the full source code difference.

### 17.4.18
- Added unit tests for both .NET 45 and .NET Core 2.0

### 17.4.15
- Fixed a bug in Samples GET request URLs when an empty collection property was serialized.

### 17.4.14
- Updated the service models for the 2017.14 release of AQUARIUS Samples
- Added connection pooling support for AQTS connections, to minimize version-probes and authentication requests. When multiple threads are independently attempting to make authenticated requests, all threads will end up sharing the same authentication session. The last thread to exit will issue the `DELETE /session` requests to clean up server-side resources. This change is hidden behind the `AquariusClient.CreateConnectedClient()` factory method, so it should be transparent to consumers of the platform SDK.

### 17.4.13 / 17.4.12 / 17.4.11
- These versions broke the fundamental AQTS connection logic and have been pulled from NuGet. Please use a newer version of the SDK to ensure reliable connections to your AQUARIUS Time-Series server.

### 17.4.9
- Updated the service models for the 2017.4 release of AQUARIUS Time-Series
- Fixed an enumeration deserialization bug, to make the SDK more robust if a new version of AQTS adds new value to an existing enumeration type.
- Marked the `PublishClient`, `AcquisitionClient`, and `ProvisioningClient` properties as obsolete, replacing them with the more succinct `Publish`, `Acquisition`, and `Provisioning` properties. The obsolete properties will be removed in a future release of the SDK.

### 17.4.8
- Added two build targets: .NET Standard and .NET Framework 4.5
- Moved the legacy service models to separate NuGet package: `Aquarius.SDK.Legacy`. Most programs won't need these older service models, so now it is much more difficult to make the wrong choice by accident.

### 17.4.3
- Updated the service model for the 2017.13 release of AQUARIUS Samples
- Fixed some JSON serialization bugs for the Samples client, for timestamp and timerange objects
- Added the `DurationExtensions.MaxGapDuration` constant
- Capped the `NodaTime` dependency version to 1.x, to avoid some breaking changes in the NodaTime 2.x code base
- Added some `PostFileWithRequest` extension methods which automatically infer the `<TResponse>` type.

### 17.3.1
- Updated the service models for the 2017.3 release of AQUARIUS Time-Series

### 17.2.32

- Upgraded the ServiceStack dependencies to v4.5.12
- Fixed a serialization bug that would truncate fractional seconds when POST-ing points to the AQTS Acquisition API
- Updated the service model for the 2017.7 release of AQUARIUS Samples

### 17.2.29

- Fixed a bug where the SDK would fail to load if the SDK assembly or the application are located in a path containing spaces.
- Added the first cut of an AQUARIUS Samples client.
 
### 17.2.26

- Fixed the file version of the SDK assembly.
- Includes the SDK version and application version in the user agent string for all requests originating from the SDK.

### 17.2.17

- Initial public release of the SDK.
