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
	echo Generates an Aquarius NG client library that matches the services running on the server
	echo
	exit_abort "$@"
}

Generator=./generate_code_from_live_endpoint.sh

ServerName=$1
OutputPath=$2

[ ! -z "$ServerName" ] || ServerName=localhost
[ ! -z "$OutputPath" ] || OutputPath=./ServiceModels

$Generator Publish Publish/v2 $ServerName $OutputPath || exit_abort
$Generator Provisioning Provisioning/v1 $ServerName $OutputPath || exit_abort
$Generator Acquisition Acquisition/v2 $ServerName $OutputPath || exit_abort
