using Library.GameMonitor;

List<MonitorApp> MonitorApps = new();

ProcConfig procConfig = new("config.txt");

foreach( var miniProcConfig in procConfig.MiniProcConfigList){
    MiniProc miniProc = new(procConfig.ProcPathTemplate,miniProcConfig);   
    Console.WriteLine("Monitor: {0} ->  {1}", miniProc.MonitorProcessName, miniProc.ProcPath); 
    MonitorApps.Add( new MonitorApp(miniProc.MonitorProcessName,miniProc.ProcPath));
}


using var monitorTimer = new PeriodicTimer(TimeSpan.FromSeconds(1));
while (await monitorTimer.WaitForNextTickAsync())
{
    foreach( var monitorApp in MonitorApps){
        monitorApp.CheckProcess();
    }    
}