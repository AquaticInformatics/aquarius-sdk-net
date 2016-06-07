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
	echo usage: `basename $0` "EndPointNamespace EndPointRelativeUrl [ServerName (default: localhost)] [OutputPath (default: .)]"
	echo
	echo Generates an Aquarius NG client service model code file via ServiceStack's built-in /types/<language> generator available on a live REST endpoint
	echo
	exit_abort "$@"
}

EndPointName=$1
EndPoint=$2
ServerName=$3
OutputPath=$4

[ ! -z "$EndPointName" ] || show_usage "No namespace! Specify a namespace for the generated code"
[ ! -z "$EndPoint" ] || show_usage "No endpoint! Specify a relative URL for the endpoint to inspect"
[ ! -z "$ServerName" ] || ServerName=localhost
[ ! -z "$OutputPath" ] || OutputPath=.

mkdir -p "$OutputPath" || exit_abort "Can't create OutputPath=$OutputPath"
echo "Determining AQUARIUS Server version ..."
ApiVersion=`curl -s http://$ServerName/AQUARIUS/apps/v1/version` || exit_abort "Can't determine AQUAIRUS server version of $ServerName"

echo "Generating $OutputFile ..."
OutputFile=$OutputPath/$EndPointName.cs
curl -s -o t.t "http://$ServerName/AQUARIUS/$EndPoint/types/csharp?MakePartial=false&MakeVirtual=false&GlobalNamespace=Aquarius.Client.$EndPointName&DefaultNamespaces=System,System.Collections,System.Collections.Generic,System.Runtime.Serialization,ServiceStack,ServiceStack.DataAnnotations,NodaTime" || exit_abort "Can't read endpoint"
echo "// Generated from: $ApiVersion" > "$OutputFile"
cat t.t >> "$OutputFile"
rm t.t
unix2dos "$OutputFile"
echo "Complete."
