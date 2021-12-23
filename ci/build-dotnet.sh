#!/bin/sh

cd game-monitor-repo
dotnet restore
dotnet build /nologo /p:PublishProfile=Release /p:WebPublishMethod=Package /p:PackageAsSingleFile=true /p:configuration="Release" /p:DesktopBuildPackageLocation="GameMonitor.zip"
#dotnet publish

#mkdir Output
#cp MiniProcess/bin/Debug/net6.0/win-x64/publish/MiniProcess.exe Output
#cp GameMonitor/bin/Debug/net6.0/win-x64/publish/GameMonitor.exe Output
#cp GameMonitor/bin/Debug/net6.0/win-x64/publish/config.txt Output

#dotnet build WebApplicationDeploy.sln /nologo /p:PublishProfile=Release /p:PackageLocation="C:SomePathpackage" /p:OutDir="C:SomePathout" /p:DeployOnBuild=true /p:WebPublishMethod=Package /p:PackageAsSingleFile=true /maxcpucount:1 /p:platform="Any CPU" /p:configuration="Release" /p:DesktopBuildPackageLocation="C:SomePathpackagepackage.zip"