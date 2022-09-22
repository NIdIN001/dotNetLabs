using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace dotNetLab2.lab2.ru.nsu.brideApplication.configuration;

public class ReportConfiguration : IHostedService
{
    private const string ReportPathConfig = "ReportConfiguration:reportPath";

    public string ReportPath { get; }

    public ReportConfiguration()
    {
        var configurationManager = new ConfigurationManager();
        configurationManager.AddJsonFile(
            "/Users/stanislavutockin/Documents/dotNetLabs/dotNetLab2/lab2/ru.nsu.brideApplication/appsettings.json");

        ReportPath = configurationManager[ReportPathConfig] ?? throw new Exception();
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}