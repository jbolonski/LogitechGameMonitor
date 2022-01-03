namespace GameMonitorService;
using Library.GameMonitor;

public class MonitorBackgroundService : BackgroundService
{
    private readonly ILogger<MonitorBackgroundService> _logger;
    private readonly List<MonitorApp> MonitorApps = new();
    private readonly ProcConfig ProcConfig;

    public MonitorBackgroundService(ILogger<MonitorBackgroundService> logger)
    {
        string? strWorkPath = Path.GetDirectoryName("config.txt");

        if (strWorkPath == null) { throw new Exception("config.txt missing."); }

        ProcConfig = new ProcConfig(strWorkPath);
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
                MiniProc miniProc = new(ProcConfig.ProcPathTemplate, miniProcConfig);
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
