using dotNetLab2.lab2.ru.nsu.brideApplication.configuration;
using dotNetLab2.lab2.ru.nsu.brideApplication.model;
using dotNetLab2.lab2.ru.nsu.brideApplication.service;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace dotNetLab2.lab2.ru.nsu.brideApplication;

public class Application
{
    public static void Main(string[] args)
    {
        var builder = CreateHostBuilder(args);
        var host = builder.Build();
        host.Run();
        host.StopAsync();
    }

    private static IHostBuilder CreateHostBuilder(string[] args)
    {
        return Host.CreateDefaultBuilder(args)
            .ConfigureServices(services =>
            {
                services.AddSingleton<ContenderConfiguration>();
                services.AddSingleton<ReportConfiguration>();
                services.AddSingleton<Friend>();
                services.AddSingleton<Princess>();
                services.AddSingleton<ContenderGeneratorService>();
                services.AddSingleton<Hall>();
                services.AddSingleton<ReportService>();
                services.AddSingleton<ThroneRoom>();
                services.AddHostedService<ApplicationService>();
            });
    }
}