using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;

namespace dotNetLab2.lab2.ru.nsu.brideApplication.configuration;

public class ContenderConfiguration : IHostedService
{
    private const string ContendersCountProperty = "SelectOptions:contendersCount";
    private const string TriesCountProperty = "SelectOptions:triesCount";
    private const string FirstnameProperty = "SelectOptions:firstname";
    private const string LastnameProperty = "SelectOptions:lastname";

    public int ContendersCount { get; }
    public int TriesCount { get; }
    public string Firstname { get; }
    public string Lastname { get; }

    public ContenderConfiguration()
    {
        var configurationManager = new ConfigurationManager();
        configurationManager.AddJsonFile(
            "/Users/stanislavutockin/Documents/dotNetLabs/dotNetLab2/lab2/ru.nsu.brideApplication/appsettings.json");

        ContendersCount = int.Parse(configurationManager[ContendersCountProperty] ?? throw new Exception());
        TriesCount = int.Parse(configurationManager[TriesCountProperty] ?? throw new Exception());
        Firstname = configurationManager[FirstnameProperty] ?? throw new Exception();
        Lastname = configurationManager[LastnameProperty] ?? throw new Exception();
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