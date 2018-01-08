#!/bin/bash

# Helper functions
exit_abort () {
	[ ! -z "$1" ] && echo ERROR: "$1"
	echo
	echo 'ABORTED!'
	exit 1
}

ServerName=$1
[ ! -z "$ServerName" ] || ServerName=https://test.gaiaserve.net

echo Building SamplesServiceModelGenerator ...
dotnet build --configuration Release || exit_abort "Can't build SamplesServiceModelGenerator"

echo Creating new Samples service model from $ServerName ...
curl -f "$ServerName/api/v1/status" || exit_abort "Can't fetch API status from $ServerName"
echo
pushd Aquarius.Client/Samples/Client
./create_service_models.sh $ServerName || exit_abort "Can't create Samples service model"
popd

echo Rebuilding SDK ...
dotnet build --configuration Release || exit_abort "Can't rebuild SDK with regenerated Samples client"

echo Running unit tests ...
dotnet test --configuration Release `find . -iname *.UnitTests.csproj` || exit_abort "Unit tests failed."
