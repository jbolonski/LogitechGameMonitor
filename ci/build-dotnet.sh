#!/bin/sh

mkdir Output

cd game-monitor-repo
dotnet restore
#dotnet build
dotnet publish

mkdir Output
cp MiniProcess/bin/Debug/net6.0/win-x64/publish/MiniProcess.exe Output
cp GameMonitor/bin/Debug/net6.0/win-x64/publish/GameMonitor.exe Output
cp GameMonitor/bin/Debug/net6.0/win-x64/publish/config.txt Output
