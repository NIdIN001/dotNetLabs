using dotNetLab2.lab2.ru.nsu.brideApplication.configuration;
using dotNetLab2.lab2.ru.nsu.brideApplication.model;
using Microsoft.Extensions.Hosting;

namespace dotNetLab2.lab2.ru.nsu.brideApplication.service;

public class ApplicationService : IHostedService
{
    private readonly ThroneRoom _throneRoom;
    private readonly Hall _hall;
    private readonly ReportService _reportService;
    private readonly ContenderConfiguration _contenderConfiguration;
    private readonly ReportConfiguration _reportConfiguration;
    private readonly Friend _friend;

    private readonly IHostApplicationLifetime _hostApplicationLifetime;

    public ApplicationService(ThroneRoom throneRoom, Hall hall,
        ContenderConfiguration contenderConfiguration, ReportConfiguration reportConfiguration,
        ReportService reportService, Friend friend,
        IHostApplicationLifetime appLifetime)
    {
        _throneRoom = throneRoom;
        _friend = friend;

        _hall = hall;
        _reportService = reportService;

        _contenderConfiguration = contenderConfiguration;
        _reportConfiguration = reportConfiguration;
        
        _hostApplicationLifetime = appLifetime;
    }

    private void Run()
    {
        File.Delete(_reportConfiguration.ReportPath);
        var totalHappiness = 0;

        for (int i = 0; i < _contenderConfiguration.TriesCount; i++)
        {
            var princessChoose = _throneRoom.ChooseHusband();
            var princessHappiness = Princess.GetHappiness(princessChoose, _hall.GetAllContenders());

            totalHappiness += princessHappiness;
            _reportService.WriteResultInReport(princessChoose, princessHappiness);

            Reset();
        }

        Console.WriteLine(totalHappiness / (float)_contenderConfiguration.TriesCount);
    }

    private void Reset()
    {
        _friend.ClearWatchedList();
        _hall.Fill();
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        Run();
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        return Task.CompletedTask;
    }
}