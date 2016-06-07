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

ServerName=$1
OutputPath=$2

[ ! -z "$ServerName" ] || ServerName=localhost
[ ! -z "$OutputPath" ] || OutputPath=./ServiceModels

./generator.sh Publish Publish/v2 $ServerName $OutputPath || exit_abort
./generator.sh Provisioning Provisioning/v1 $ServerName $OutputPath || exit_abort
./generator.sh Acquisition Acquisition/v2 $ServerName $OutputPath || exit_abort
./generator.sh Processor Processor $ServerName $OutputPath || exit_abort
./generator.sh FieldData apps/v1 $ServerName $OutputPath || exit_abort
