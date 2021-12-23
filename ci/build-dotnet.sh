#!/bin/sh

cd game-monitor-repo
dotnet restore
dotnet build
dotnet publish

ls MiniProcess/bin/Debug/net6.0/win-x64/publish
ls GameMonitor/bin/Debug/net6.0/win-x64/publish