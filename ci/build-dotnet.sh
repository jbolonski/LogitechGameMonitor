#!/bin/sh

apt-get update -qq -y
apt-get install -qq zip -y

cd game-monitor-repo
dotnet restore
dotnet publish --configuration Release

#####################################################
# Prep Output Directory
#####################################################
mkdir Output

#####################################################
# Copy Files to Output Directory
#####################################################
cp MiniProcess/bin/Release/net6.0/win-x64/publish/MiniProcess.exe Output
cp GameMonitorService/bin/Release/net6.0/win-x64/publish/GameMonitorService.exe Output
cp GameMonitorService/bin/Release/net6.0/win-x64/publish/config.txt Output

#####################################################
# Create Install/Uninstall Scripts for the Service
#####################################################
echo >Output/install.ps1 'sc.exe create "Game Monitor Service" binpath= "$($PSScriptRoot)\GameMonitorService.exe" start= auto'
echo >>Output/install.ps1 'sc.exe description "Game Monitor Service" "Config at $($PSScriptRoot)"'
echo >Output/uninstall.ps1 'sc.exe delete "Game Monitor Service"'

#####################################################
# Create Zip File
#####################################################
cd Output
zip GameMonitor.zip MiniProcess.exe GameMonitorService.exe config.txt install.ps1 uninstall.ps1

ls