@echo off

set config=%1
if "%config%" == "" (
   set config=Release
)

set version=
if not "%PackageVersion%" == "" (
   set version=-Version %PackageVersion%
)

rem Package restore
call "%NuGet%" restore src
if not "%errorlevel%"=="0" goto failure

rem Build
call "%MsBuildExe%" build.proj /p:Configuration="%config%" /m /v:M /fl /flp:LogFile=msbuild.log;Verbosity=Normal /nr:false
if not "%errorlevel%"=="0" goto failure

rem Tests
set NUnitRunner=src\packages\NUnit.Runners.2.6.3\tools\nunit-console.exe
call "%NUnitRunner%" /config:%config% /framework:net-4.5 src\Aquarius.Client.UnitTests\bin\%config%\Aquarius.Client.UnitTests.dll
if not "%errorlevel%"=="0" goto failure

rem Package create
mkdir Build
rem call "%NuGet%" pack "src\Aquarius.Client\Aquarius.Client.csproj" -symbols -o Build -p Configuration=%config% %version%
if not "%errorlevel%"=="0" goto failure

:success
exit 0

:failure
exit -1
