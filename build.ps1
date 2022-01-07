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

cp GameMonitorService/bin/Release/net6.0-windows/win-x64/publish/config.txt Output
cp GameMonitorService/bin/Release/net6.0-windows/win-x64/publish/GameMonitorService.exe Output

#####################################################
# Copy Install/Uninstall Scripts for the Application
#####################################################
cp install.ps1 Output
cp uninstall.ps1 Output