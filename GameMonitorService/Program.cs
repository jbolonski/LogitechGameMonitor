using GameMonitorService;
using Microsoft.Extensions.Logging.EventLog;

IHost host = Host.CreateDefaultBuilder(args)
    .UseWindowsService(options => {
        options.ServiceName = "Game Monitor Service";
    })
    .ConfigureServices(services =>
    {
        services.AddHostedService<MonitorBackgroundService>().Configure<EventLogSettings>(config => {
            config.LogName = "Game Monitor Service";
            config.SourceName = "Game Monitor Service Source";
        });
    }).Build();

await host.RunAsync();
