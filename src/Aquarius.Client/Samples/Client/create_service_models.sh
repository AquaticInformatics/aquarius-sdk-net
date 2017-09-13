#!/bin/bash

# This is can be installed in your ~/bin folder, outside of any repo.

# Helper functions
exit_abort () {
	[ ! -z "$1" ] && echo ERROR: "$1"
	echo
	echo 'ABORTED!'
	exit $ERRCODE
}

show_usage() {
	echo usage: `basename $0` "[ServerName (default: localhost)] [OutputPath (default: ./ServiceModels)]"
	echo
	echo Generates an Aquarius Samples client library that matches the services running on the server
	echo
	exit_abort "$@"
}

Generator=../../../SamplesServiceModelGenerator/bin/Release/SamplesServiceModelGenerator.exe

ServerName=$1
OutputPath=$2

[ -f "$Generator" ] || exit_abort "Can't find $Generator. You'll need to build it first."
[ ! -z "$ServerName" ] || ServerName=https://demo.aqsamples.com
[ ! -z "$OutputPath" ] || OutputPath=./ServiceModel.cs

$Generator -filename=$OutputPath -url=$ServerName/api/swagger.json || exit_abort
