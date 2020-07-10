## AQUARIUS.SDK Release Notes

This page highlights some changes in the SDK.

Not all changes will be listed, but you can always [compare by version tags](https://github.com/AquaticInformatics/aquarius-sdk-net/compare/v17.2.21...v17.2.25) to see the full source code difference.

### 20.2.0
- Updated the service models for the AQUARIUS Time-Series 2020.2 release.

### 20.1.0
- Updated the service models for the AQUARIUS Time-Series 2020.1 release.

### 20.0.6
- Samples API: Disable 3xx redirect following, so that the ISamplesClient.LocationResponseHeader string can be tracked from all requests.

### 20.0.5
- Samples API: Query parameters for file uplaod requests are now properly camelCased.
- Added ISamplesClient.LocationResponseHeader string to reflect the last received Location header response (useful for tracking file upload URL responses)

### 20.0.4
- Updated the service models for the AQUARIUS Samples 2020.03 release.

### 20.0.3
- Updated the internal ServiceStack libraries to v5.8.0, for both .NET Framework and .NET Core.

### 20.0.1
- Updated the service models for the AQUARIUS Samples 2020.1 release.

### 19.4.2
- Updated the service models for the AQUARIUS Time-Series 2019.4 Update 1 release.

### 19.4.1
- No external changes, just some internal build plumbing fixes.

### 19.4.0
- Updated the service models for the AQUARIUS Time-Series 2019.4 release.

### 19.3.0
- Updated the service models for the AQUARIUS Time-Series 2019.3 release.

### 19.2.4
- Updated the service models for the AQUARIUS Time-Series 2019.2 Update 1 release. (Build 19.2.185) This update allows grades and qualifiers to be appended to basic time-series points, in addition to values.
- **Source code change required:** Replace "ReflectedTimeSeriesPoint" with "TimeSeriesPoint"
    - The `ReflectedTimeSeriesPoint` request DTO class has been removed, since its parent class `TimeSeriesPoint` can now be used for both appends to basic or reflected time-series.
    - If your integration was appending to reflect time-series, just rename all instances of `ReflectedTimeSeriesPoint` to `TimeSeriesPoint`.
    - Code compiled against SDK 19.2.4 continues to be compatible with earlier versions of AQTS.

### 19.2.3
- An internal change to improve the robustness of the `SendBatchRequests` helper method. Now it will continue to work even if a server version renames an internal request DTO class.

### 19.2.0
- Updated the service models for the AQUARIUS Time-Series 2019.2 release.

### 19.1.0
- Updated the service models for the AQUARIUS Time-Series 2019.1 release.

### 18.8.1
- Updated the service models for the AQUARIUS Time-Series 2018.4 release.
- Integrations consuming the `GET /Publish/v2/GetFieldDataByLocation` response should update to the 18.8 SDK as soon as possible, to avoid `ArgumentException` errors when deserializing the new `CrossSectionSurvey` activity type introduced in AQTS 2018.4.

### 18.7.4
- Fixed a connection pool race condition which would lose the authenticated session when the SessionKeepAlive() timer expired.
- Clients performing multi-threaded requests are urged to update to this SDK version. See Issue #83 for details.

### 18.7.3
- `ReadEntireResponseTimeout` now actually defaults to 5 minutes as documented, instead of 4 minutes.

### 18.7.2
- Added configurable timeout properties for `SdkServiceClient` requests.
- `FirstByteReceivedTimeout` defaults to 3 minutes.
- `ReadEntireResponseTimeout` defaults to 5 minutes.

### 18.7.1
- Updated the service models for the AQUARIUS Time-Series 2018.3 release.

### 18.6.4
- Fixed a bug in the auto-generated user-agent header. Now the SDK version is reported correctly, even from single-EXE deployments.

### 18.6.3
- Automatically re-authenticate an AQTS session if it expires. This means the `SessionKeepAlive()` method becomes obsolete.

### 18.6.1
- Updated the service models for the AQUARIUS Time-Series 2018.2 release.

### 18.5.2
- Fixed a potential deadlock in the connection-pooling logic for AQTS connections.

This deadlock could occur when a heavily-threaded process was making many parallel connections to the AQTS app server. The bug was introduced in SDK v17.4.14, released on 2017-Dec-20, so all consumers of the .NET SDK are encouraged to upgrade to the latest SDK version to avoid this deadlock.

### 18.5.1
- Updated the service models for the AQUARIUS Samples 2018.05 release.

### 18.4.1
- Updated the service models for the AQUARIUS Samples 2018.04 release.

### 18.3.2
- Improved the Samples file upload API to support extra multi-part content

### 18.3.1
- Updated the service models for the AQUARIUS Time-Series 2018.1 release.
- Updated the service models for the AQUARIUS Samples 2018.03 release.
- Note that some of the previous Samples request DTOs have been marked as `[Obsolete]` and will be removed in a future release of the SDK. Please update your code as needed.

### 18.2.1
- Updated the service models for the AQUARIUS Samples 2018.02 release.

### 18.1.1
- Updated the service models for the AQUARIUS Samples 2018.01 release.

### 17.4.18
- Added unit tests for both .NET 45 and .NET Core 2.0

### 17.4.15
- Fixed a bug in Samples GET request URLs when an empty collection property was serialized.

### 17.4.14
- Updated the service models for the AQUARIUS Samples 2017.14 release
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
