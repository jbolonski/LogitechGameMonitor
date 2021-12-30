namespace Library.GameMonitor;

public class MiniProc{
    public string ProcPath {get;private set;}
    public string MonitorProcessName { get; private set; }
    public MiniProc(string miniProcPathTemplate,string processName){
        ProcPath = InitMiniProc(miniProcPathTemplate, processName);
        MonitorProcessName = processName;
    }
    private static string InitMiniProc(string miniProcPathTemplate, string processName)
    {
        string templateFileName = Path.GetFileName(miniProcPathTemplate);
        string? directory = Path.GetDirectoryName(miniProcPathTemplate);
        string miniProcPath = Path.Join(directory, string.Format("Trigger-{0}.exe", processName));

        if (File.Exists(miniProcPath))
        {
            return miniProcPath;
        }

        Console.WriteLine("Create Mini Proc --> {0}  to {1}", templateFileName,miniProcPath);
        File.Copy(templateFileName, miniProcPath);
        return miniProcPath;
    }
}