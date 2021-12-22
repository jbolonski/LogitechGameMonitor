#!/bin/sh

cd game-monitor-repo
dotnet restore
dotnet build
dotnet publish