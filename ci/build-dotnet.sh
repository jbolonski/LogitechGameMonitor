#!/bin/sh

cd game-monitor-repo
dotnet restore
dotnet build
dotnet publish

mkdir Output
cp MiniProcess/bin/Debug/net6.0/win-x64/publish/MiniProcess.exe Output
cp GameMonitor/bin/Debug/net6.0/win-x64/publish/GameMonitor.exe Output
cp GameMonitor/bin/Debug/net6.0/win-x64/publish/config.txt Output

cd Output
zip -r GameMonitor.zip *.exe *.txt

ls 