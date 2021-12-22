#!/bin/sh

cd game-monitor-repo/GameMonitor
dotnet restore
dotnet build
#dotnet publish