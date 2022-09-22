using dotNetLab2.lab2.ru.nsu.brideApplication.model;
using Microsoft.Extensions.Hosting;

namespace dotNetLab2.lab2.ru.nsu.brideApplication.service;

public class ThroneRoom : IHostedService
{
    private readonly Princess _princess;
    private readonly Hall _hall;

    public ThroneRoom(Princess princess, Hall hall)
    {
        _princess = princess;
        _hall = hall;
    }

    public Contender? ChooseHusband()
    {
        for (int i = 0; i < _hall.GetContendersCount(); i++)
        {
            var contender = _hall.GetByIndex(i);

            var isSelected = _princess.MakeDecision(contender);
            if (isSelected)
            {
                return contender;
            }
        }

        return null;
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