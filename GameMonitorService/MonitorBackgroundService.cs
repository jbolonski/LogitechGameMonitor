namespace GameMonitorService;
using Library.GameMonitor;

public class MonitorBackgroundService : BackgroundService
{
    private readonly ILogger<MonitorBackgroundService> _logger;
    private readonly List<MonitorApp> MonitorApps = new();
    private readonly ProcConfig ProcConfig;
    private readonly string AppBaseDir;

    public MonitorBackgroundService(ILogger<MonitorBackgroundService> logger)
    {
        Directory.SetCurrentDirectory(AppDomain.CurrentDomain.BaseDirectory);
        AppBaseDir = AppContext.BaseDirectory;
        string? strConfigPath = Path.Join(AppBaseDir, "config.txt");
        if (strConfigPath == null) { throw new Exception("config.txt missing."); }

        ProcConfig = new ProcConfig(AppBaseDir,"config.txt");
        _logger = logger;
    }

    protected override async Task ExecuteAsync(CancellationToken stoppingToken)
    {
        while (!stoppingToken.IsCancellationRequested)
        {
            _logger.LogInformation(
                "Monitor running at: {time}",
                DateTimeOffset.Now);

            foreach (var miniProcConfig in ProcConfig.MiniProcConfigList)
            {
                string ProcPathTemplateFullPath = Path.Join(ProcConfig.BasePath, ProcConfig.ProcPathTemplate);
                MiniProc miniProc = new(ProcPathTemplateFullPath, miniProcConfig);
                _logger.LogInformation(
                    "Monitor: {0} ->  {1}",
                    miniProc.MonitorProcessName,
                    miniProc.ProcPath);
                MonitorApps.Add(new MonitorApp(miniProc.MonitorProcessName, miniProc.ProcPath));
            }

            using var monitorTimer = new PeriodicTimer(TimeSpan.FromSeconds(1));

            while (await monitorTimer.WaitForNextTickAsync(stoppingToken))
            {
                foreach (var monitorApp in MonitorApps)
                {
                    monitorApp.CheckProcess();
                }
            }

        }
    }
}
