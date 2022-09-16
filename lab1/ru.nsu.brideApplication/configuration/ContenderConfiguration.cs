using Microsoft.Extensions.Configuration;

namespace dotNetLabs.lab1.ru.nsu.brideApplication.configuration;

public class ContenderConfiguration
{
    private const string ContendersCountProperty = "SelectOptions:contendersCount";
    private const string TriesCountProperty = "SelectOptions:triesCount";

    public int ContendersCount { get; }

    public int TriesCount { get; }

    public ContenderConfiguration(IConfiguration configurationManager)
    {
        ContendersCount = int.Parse(configurationManager[ContendersCountProperty] ?? throw new Exception());
        TriesCount = int.Parse(configurationManager[TriesCountProperty] ?? throw new Exception());
    }
}