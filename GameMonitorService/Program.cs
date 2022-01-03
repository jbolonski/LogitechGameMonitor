using GameMonitorService;

IHost host = Host.CreateDefaultBuilder(args)
    .UseWindowsService(options => {
        options.ServiceName = "Game Monitor Service";
    })
    .ConfigureServices(services =>
    {
        services.AddHostedService<MonitorBackgroundService>();
    })
    .Build();

await host.RunAsync();
