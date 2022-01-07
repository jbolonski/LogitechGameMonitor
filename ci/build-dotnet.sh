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
cp GameMonitorService/bin/Release/net6.0-windows/win-x64/publish/GameMonitorService.exe Output
cp GameMonitorService/bin/Release/net6.0-windows/win-x64/publish/config.txt Output

#####################################################
# Copy Install/Uninstall Scripts for the Application
#####################################################
cp install.ps1 Output
cp uninstall.ps1 Output

#####################################################
# Create Zip File
#####################################################
cd Output
zip GameMonitor.zip MiniProcess.exe GameMonitorService.exe config.txt install.ps1 uninstall.ps1

ls