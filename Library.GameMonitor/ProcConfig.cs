namespace Library.GameMonitor;

public class ProcConfig{
    public string BasePath { get;private set; }
    public string ConfigFile { get;private set; }
    public string ProcPathTemplate{get;private set;}
    public List<string> MiniProcConfigList = new();
    public ProcConfig(string path,string configfile){
        BasePath = path;
        ConfigFile = configfile;

        IEnumerable<String> configLines = File.ReadLines(Path.Join(BasePath, ConfigFile));
        ProcPathTemplate = configLines.First();

        foreach(var procConfig in configLines.Skip(2)){    
            MiniProcConfigList.Add(procConfig);
        }
    }
}