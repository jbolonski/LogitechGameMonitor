dotnet restore
dotnet publish

New-Item -ItemType Directory -Force -Path Output

cp MiniProcess/bin/Debug/net6.0/win-x64/publish/MiniProcess.exe Output
cp GameMonitor/bin/Debug/net6.0/win-x64/publish/GameMonitor.exe Output
cp GameMonitor/bin/Debug/net6.0/win-x64/publish/config.txt Output