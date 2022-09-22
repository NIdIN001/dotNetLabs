using dotNetLab2.lab2.ru.nsu.brideApplication.configuration;
using dotNetLab2.lab2.ru.nsu.brideApplication.model;
using dotNetLab2.lab2.ru.nsu.brideApplication.util;
using Microsoft.Extensions.Hosting;

namespace dotNetLab2.lab2.ru.nsu.brideApplication.service;

public class ContenderGeneratorService : IHostedService
{
    private readonly ContenderConfiguration _contenderConfiguration;
    private readonly List<int> _possibleAttractiveness;
    private readonly ContenderNameProvider _contenderNameProvider;

    public ContenderGeneratorService(ContenderConfiguration contenderConfiguration)
    {
        _contenderConfiguration = contenderConfiguration;
        _contenderNameProvider = new ContenderNameProvider(_contenderConfiguration.Firstname,
            _contenderConfiguration.Lastname);
        _possibleAttractiveness = new List<int>();
    }

    public Contender GenerateContender()
    {
        var index = RandomProvider.GetRandom().Next(_possibleAttractiveness.Count);
        var attractiveness = _possibleAttractiveness[index];
        _possibleAttractiveness.RemoveAt(index);

        return new Contender(_contenderNameProvider.GetName(), _contenderNameProvider.GetSurname(), attractiveness);
    }

    public void FillPossibleAttractiveness()
    {
        _possibleAttractiveness.Clear();
        for (int i = 0; i < _contenderConfiguration.ContendersCount; i++)
        {
            _possibleAttractiveness.Add(i + 1);
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