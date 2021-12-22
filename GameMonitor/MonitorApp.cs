using System.Diagnostics;

class MonitorApp{
    public string ProcessName {get;set;}="";
    public string LaunchProcess {get;set;}="";
    public bool IsRunning {get;set;}=false;

    private Process? TriggerProcess;

    public MonitorApp(){
        Init("","");
    }

    public MonitorApp(string processName, string launchProcess){
        Init(processName,launchProcess);
    }

    private void Init(string processName, string launchprocess){
        ProcessName = processName;
        LaunchProcess = launchprocess;
    }

    private void LaunchTriggerProcess(){
        // start stub app -- If it isn't running already
        Console.WriteLine("Launching : {0}",LaunchProcess);
        TriggerProcess = new();
        TriggerProcess.StartInfo.FileName = LaunchProcess;
        TriggerProcess.Start();
    }

    private void CloseTriggerProcess(){
        if( TriggerProcess != null){
            Console.WriteLine("Closing : {0}",LaunchProcess);
            TriggerProcess.Kill(true);
            TriggerProcess=null;
        }
    }

    public bool CheckProcess(){
        Process[] processByName = Process.GetProcessesByName(ProcessName);
        if( processByName.Length >0 ){
            if( !IsRunning ){
                Console.WriteLine("found process> {0}",processByName[0].ProcessName);                
                IsRunning=true;
                LaunchTriggerProcess();
            }
        } else {
            if(IsRunning){
                Console.WriteLine("process stopped> {0}",ProcessName);
                CloseTriggerProcess();
                IsRunning=false;
            }
        }

        return IsRunning;
    }
}