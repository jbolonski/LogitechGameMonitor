#!/bin/sh

ls -al /

cd game-monitor-repo/MiniProcess
dotnet restore
dotnet build
dotnet publish

cd ../game-monitor-repo/GameMonitor
dotnet restore
dotnet build
dotnet publish