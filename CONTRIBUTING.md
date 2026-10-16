# CONTRIBUTING

Contributions are always welcome, no matter how large or small. Before contributing,
please read the [code of conduct](CODE_OF_CONDUCT.md).

## Setup

1. Install Visual Studio 2022+ on your system (Community Edition should be fine): https://www.visualstudio.com/
1. Fork the repo: https://github.com/AquaticInformatics/aquarius-sdk-net

## Building

Either build from within Visual Studio, or run `dotnet build src` from the root of the repo.

## Testing

The NUnit-based test suite can be run from with Visual Studio.

### Samples API integration tests

`SamplesApiIntegrationTests` in the `Aquarius.Client.IntegrationTests` project
sends real requests to an AQUARIUS Samples API, separate from the unit tests.
The fixture is marked `[Explicit]`, so normal test runs do not execute it.
An explicit name filter that matches this fixture, including a broad namespace
filter, can select it for execution.
Set `SAMPLES_CLIENT` to the server URL and `SAMPLES_TOKEN` to an API token
with permission to read activities and create/update sampling locations,
field visits, and activities. Use a non-production test server.

Run the fixture explicitly with the Bash script (from the repository root):

```sh
bash src/test_samples_integration.sh
```

## Pull Requests

We actively welcome your pull requests.

1. Fork the repo and create your branch from `develop`.
2. If you've added code that should be tested, add tests.
4. Ensure the test suite passes.

## License

By contributing to the Aquarius SDK, you agree that your contributions will be licensed
under its [AGPLv3 license](LICENSE.txt).
