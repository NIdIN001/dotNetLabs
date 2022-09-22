using dotNetLab2.lab2.ru.nsu.brideApplication.configuration;
using dotNetLab2.lab2.ru.nsu.brideApplication.model;
using Microsoft.Extensions.Hosting;

namespace dotNetLab2.lab2.ru.nsu.brideApplication.service;

public class Hall : IHostedService
{
    private readonly ContenderGeneratorService _contenderGeneratorService;
    private readonly ContenderConfiguration _contenderConfiguration;

    private readonly List<Contender> _allContenders;

    public Hall(ContenderGeneratorService contenderGenerator, ContenderConfiguration contenderConfiguration)
    {
        _contenderConfiguration = contenderConfiguration;
        _contenderGeneratorService = contenderGenerator;
        _allContenders = new List<Contender>();

        Fill();
    }

    public Contender GetByIndex(int index)
    {
        return _allContenders[index];
    }

    public List<Contender> GetAllContenders()
    {
        return _allContenders;
    }

    public int GetContendersCount()
    {
        return _contenderConfiguration.ContendersCount;
    }

    public void Clear()
    {
        _allContenders.Clear();
    }

    public void Fill()
    {
        Clear();
        _contenderGeneratorService.FillPossibleAttractiveness();
        while (_allContenders.Count < _contenderConfiguration.ContendersCount)
        {
            _allContenders.Add(_contenderGeneratorService.GenerateContender());
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