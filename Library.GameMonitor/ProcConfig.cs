namespace Library.GameMonitor;

public class ProcConfig{
    public string ProcPathTemplate{get;private set;}
    public List<string> MiniProcConfigList = new();
    public ProcConfig(string path){
        IEnumerable<String> configLines = File.ReadLines(path);
        ProcPathTemplate = configLines.First();

        foreach(var procConfig in configLines.Skip(2)){    
            MiniProcConfigList.Add(procConfig);
        }
    }
}