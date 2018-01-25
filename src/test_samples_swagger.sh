#!/bin/bash

# Helper functions
exit_abort () {
	[ ! -z "$1" ] && echo ERROR: "$1"
	echo
	echo 'ABORTED!'
	exit 1
}

[ -f "Aquarius.SDK.sln" ] || exit_abort "This script must be run from <repo>/src folder."

ServerName=$1
Configuration=$2
[ ! -z "$ServerName" ] || ServerName=https://test.gaiaserve.net
[ ! -z "$Configuration" ] || Configuration=Release

echo Building SamplesServiceModelGenerator ...
dotnet build --configuration $Configuration || exit_abort "Can't build SamplesServiceModelGenerator."

echo Creating new Samples service model from $ServerName ...
pushd Aquarius.Client/Samples/Client
./create_service_models.sh $ServerName || exit_abort "Can't create Samples service model."
popd

echo Showing service model diff ...
git diff

echo Rebuilding SDK ...
dotnet build --configuration $Configuration || exit_abort "Can't rebuild SDK with regenerated Samples client"

echo Running unit tests ...
dotnet test --configuration $Configuration Aquarius.Client.UnitTests/Aquarius.Client.UnitTests.csproj || exit_abort "Unit tests failed."

exit 0
