#!/bin/bash

# This is can be installed in your ~/bin folder, outside of any repo.

# Helper functions
exit_abort () {
	[ ! -z "$1" ] && echo ERROR: "$1"
	echo
	echo 'ABORTED!'
	exit 1
}

show_usage() {
	echo usage: `basename $0` "[ServerName (default: localhost)] [OutputPath (default: ./ServiceModels)]"
	echo
	echo Generates an Aquarius Samples client library that matches the services running on the server
	echo
	exit_abort "$@"
}

Generator=../../../SamplesServiceModelGenerator/bin/Release/net6.0/SamplesServiceModelGenerator.dll

ServerName=$1
OutputPath=$2

command -v dotnet >/dev/null 2>&1 || exit_abort "This script requires the .NET CORE runtime. Grab it from here: https://www.microsoft.com/net/download"
[ -f "$Generator" ] || exit_abort "Can't find $Generator. You'll need to build it first."
[ ! -z "$ServerName" ] || ServerName=https://demo.aqsamples.com
[ ! -z "$OutputPath" ] || OutputPath=./ServiceModel.cs

dotnet $Generator -filename=$OutputPath -url=$ServerName/api/swagger.json || exit_abort
