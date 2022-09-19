using Microsoft.Extensions.Configuration;

namespace dotNetLab1.lab1.ru.nsu.brideApplication.configuration;

public class ReportConfiguration
{
    private const string ReportPathConfig = "ReportConfiguration:reportPath";

    public string ReportPath { get; }

    public ReportConfiguration(IConfiguration configurationManager)
    {
        ReportPath = configurationManager[ReportPathConfig] ?? throw new Exception();
    }
}