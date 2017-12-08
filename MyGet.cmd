@echo off

set config=%1
if "%config%" == "" (
   set config=Release
)

set version=
if not "%PackageVersion%" == "" (
   set version=-Version %PackageVersion%
   echo Applying version number %PackageVersion% ...
   powershell -Command "foreach ($path in dir -Filter AssemblyInfo.cs -Recurse | %%{$_.FullName}){ (gc $path) -replace '0.0.0.0', '%PackageVersion%' | Out-File -Encoding utf8 $path }"
   powershell -Command "foreach ($path in dir -Filter Aquarius.Client.csproj -Recurse | %%{$_.FullName}){ (gc $path) -replace '0.0.0.0', '%PackageVersion%' | Out-File -Encoding utf8 $path }"
)

rem Package restore
echo Restoring packages ...
call "%NuGet%" restore src
if not "%errorlevel%"=="0" goto failure
dotnet restore src
if not "%errorlevel%"=="0" goto failure

rem Build
echo Building project ...
dotnet build --configuration "%config%"
rem call "%MsBuildExe%" build.proj /p:Configuration="%config%" /m /v:M /fl /flp:LogFile=msbuild.log;Verbosity=Normal /nr:false
if not "%errorlevel%"=="0" goto failure

rem Tests
set NUnitRunner=src\packages\NUnit.Runners.2.6.3\tools\nunit-console.exe
echo Running tests ...
call "%NUnitRunner%" /config:%config% /framework:net-4.5 src\Aquarius.Client.UnitTests\bin\%config%\Aquarius.Client.UnitTests.dll
if not "%errorlevel%"=="0" goto failure

rem Package create
mkdir Build
echo Creating packages ...
rem call "%NuGet%" pack "src\Aquarius.Client\Aquarius.Client.csproj" -symbols -o Build -p Configuration=%config% %version%
dotnet pack --output Build --configuration "%config%" "src\Aquarius.Client\Aquarius.Client.csproj"
if not "%errorlevel%"=="0" goto failure

:success
exit /b 0

:failure
exit /b -1
