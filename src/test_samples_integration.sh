#!/usr/bin/env bash
set -euo pipefail

if [[ -z "${SAMPLES_CLIENT:-}" || -z "${SAMPLES_TOKEN:-}" ]]; then
    echo "ERROR: Set SAMPLES_CLIENT and SAMPLES_TOKEN before running the Samples integration tests." >&2
    exit 1
fi

script_dir="$(cd -- "$(dirname -- "${BASH_SOURCE[0]}")" && pwd)"
cd -- "$script_dir"

echo "Running live Samples API tests. Created records will be left on the server for inspection."

# The name filter opts into the NUnit fixture marked [Explicit].
exec dotnet test Aquarius.Client.IntegrationTests/Aquarius.Client.IntegrationTests.csproj \
    --framework net10.0 \
    --filter 'FullyQualifiedName~SamplesApiIntegrationTests' \
    --logger 'console;verbosity=detailed'
