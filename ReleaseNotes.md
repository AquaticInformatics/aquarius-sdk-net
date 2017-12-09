## AQUARIUS.SDK Release Notes

This page highlights some changes in the SDK.

Not all changes will be listed, but you can always [compare by version tags](https://github.com/AquaticInformatics/aquarius-sdk-net/compare/v17.2.21...v17.2.25) to see the full source code difference.

### 17.4.8
- Added two build targets: .NET Standard and .NET Framework 4.5
- Moved the legacy service models to separate NuGet package: `Aquarius.SDK.Legacy`. Most programs won't need these older service models, so now it is much more difficult to make the wrong choice by accident.

### 17.4.3
- Updated the service models for the 2017.4 release of AQUARIUS Time-Series
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
