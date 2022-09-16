using dotNetLabs.lab1.ru.nsu.brideApplication.configuration;
using dotNetLabs.lab1.ru.nsu.brideApplication.model;

namespace dotNetLabs.lab1.ru.nsu.brideApplication.service;

public class ReportService
{
    private readonly ReportConfiguration _configuration;

    public ReportService(ReportConfiguration configuration)
    {
        _configuration = configuration;
    }

    public void WriteResultInReport(Contender? contender, int princessHappiness)
    {
        using (StreamWriter streamWriter = new(_configuration.ReportPath, append: true))
        {
            if (contender != null)
            {
                streamWriter.WriteLineAsync($"{contender.Name} {contender.Surname} {princessHappiness}");
            }
            else
            {
                streamWriter.WriteLineAsync("принцесса никого не выбрала!");
            }
        }
    }
}