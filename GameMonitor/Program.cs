using System.Collections.Generic;

List<MonitorApp> MonitorApps = new();

System.Collections.Generic.IEnumerable<String> configLines = File.ReadLines("config.txt");

string miniProcPathTemplate = configLines.First();

string SetupMiniProc(string miniProcPathTemplate,string processName){
    string templateFileName = Path.GetFileName(miniProcPathTemplate);
    string? directory = Path.GetDirectoryName(miniProcPathTemplate);

    string miniProcPath = Path.Join(directory,String.Format("Trigger-{0}.exe",processName)); 
    Console.WriteLine(miniProcPath);
    if(!File.Exists(miniProcPath)){
        File.Copy(miniProcPathTemplate,miniProcPath);
    }
    return miniProcPath;
}


foreach(var procConfig in configLines.Skip(1)){    
    string miniProcPath = SetupMiniProc(miniProcPathTemplate,procConfig);
    Console.WriteLine("{0}   {1}",procConfig,miniProcPath);
    MonitorApps.Add( new MonitorApp(procConfig,miniProcPath)  );
}

using var monitorTimer = new PeriodicTimer(TimeSpan.FromSeconds(1));
while (await monitorTimer.WaitForNextTickAsync())
{
    foreach( var monitorApp in MonitorApps){
        monitorApp.CheckProcess();
    }    
}