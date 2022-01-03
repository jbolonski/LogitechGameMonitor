dotnet restore
dotnet publish --configuration Release

#####################################################
# Prep Output Directory
#####################################################
New-Item -ItemType Directory -Force -Path Output
Get-ChildItem -Path Output | foreach { $_.Delete() }

#####################################################
# Copy Files to Output Directory
#####################################################
cp MiniProcess/bin/Release/net6.0/win-x64/publish/MiniProcess.exe Output
cp GameMonitorService/bin/Release/net6.0/win-x64/publish/config.txt Output
cp GameMonitorService/bin/Release/net6.0/win-x64/publish/GameMonitorService.exe Output

#####################################################
# Create Install/Uninstall Scripts for the Service
#####################################################
Set-Content Output/install.ps1 'sc.exe create "Game Monitor Service" binpath= "$($PSScriptRoot)\GameMonitorService.exe"'
Set-Content Output/uninstall.ps1 'sc.exe delete "Game Monitor Service"'