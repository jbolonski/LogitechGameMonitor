$objShell = New-Object -ComObject ("WScript.Shell")
$objShortCut = $objShell.CreateShortcut($env:USERPROFILE + "\Start Menu\Programs\Startup\GameMonitorService.lnk")
$objShortCut.TargetPath="$($PSScriptRoot)\GameMonitorService.exe"
$objShortCut.WorkingDirectory = "$($PSScriptRoot)"
$objShortCut.WindowStyle = 7
$objShortCut.Save()