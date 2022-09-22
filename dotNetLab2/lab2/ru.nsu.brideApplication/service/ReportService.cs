using dotNetLab2.lab2.ru.nsu.brideApplication.configuration;
using dotNetLab2.lab2.ru.nsu.brideApplication.model;
using Microsoft.Extensions.Hosting;

namespace dotNetLab2.lab2.ru.nsu.brideApplication.service;

public class ReportService : IHostedService
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

    public Task StartAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}