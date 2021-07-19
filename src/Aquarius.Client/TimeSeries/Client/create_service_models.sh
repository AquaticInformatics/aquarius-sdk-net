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

[ ! -z "$ServerName" ] || ServerName=https://aqts-rel-pg.aquariusdev.net
[ ! -z "$OutputPath" ] || OutputPath=./ServiceModels

$Generator Publish Publish/v2 $ServerName $OutputPath || exit_abort
$Generator Provisioning Provisioning/v1 $ServerName $OutputPath || exit_abort
$Generator Acquisition Acquisition/v2 $ServerName $OutputPath || exit_abort

# This hack works around the double enum definition of DeploymentMethodType
if [[ `grep -c "enum DeploymentMethodType" $OutputPath/Publish.cs` -eq "2" ]]
then
  echo "Cleaning up the generated Publish API service model ..."

  # Grab the first 30 lines, with leading line numbers, after the first enum definition.
  context=`grep -n "public enum DeploymentMethodType" --max-count=1 --after-context=30 ServiceModels/Publish.cs`

  # Capture the first line to delete
  startLine=`echo $context | cut -d':' -f 1`

  # Capture the last line of the enum definition to delete
  endLine=`echo $context | cut -d'}' -f 1 | sed -E -n -e "s/(^.*), ([0-9]+)- $/\2/p"`

  # Now we can delete the line range from the Publish service model
  sed -i -e "${startLine},${endLine}d" $OutputPath/Publish.cs
fi
