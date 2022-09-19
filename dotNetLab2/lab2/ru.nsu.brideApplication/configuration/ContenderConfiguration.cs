using Microsoft.Extensions.Configuration;

namespace dotNetLab2.lab2.ru.nsu.brideApplication.configuration;

public class ContenderConfiguration
{
    private const string ContendersCountProperty = "SelectOptions:contendersCount";
    private const string TriesCountProperty = "SelectOptions:triesCount";
    private const string FirstnameProperty = "SelectOptions:firstname";
    private const string LastnameProperty = "SelectOptions:lastname";

    public int ContendersCount { get; }

    public int TriesCount { get; }

    public string Firstname { get; }

    public string Lastname { get; }

    public ContenderConfiguration(IConfiguration configurationManager)
    {
        ContendersCount = int.Parse(configurationManager[ContendersCountProperty] ?? throw new Exception());
        TriesCount = int.Parse(configurationManager[TriesCountProperty] ?? throw new Exception());
        Firstname = configurationManager[FirstnameProperty] ?? throw new Exception();
        Lastname = configurationManager[LastnameProperty] ?? throw new Exception();
    }
}