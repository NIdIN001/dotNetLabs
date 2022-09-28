using dotNetLab2.lab2.ru.nsu.brideApplication.configuration;
using dotNetLab2.lab2.ru.nsu.brideApplication.model.strategy;
using Microsoft.Extensions.Hosting;

namespace dotNetLab2.lab2.ru.nsu.brideApplication.model;

public class Princess : IHostedService
{
    private readonly IVoteStrategy _voteStrategy;

    /* NoArgsConstructor для тестов */
    public Princess()
    {
    }

    public Princess(Friend friend, ContenderConfiguration configuration)
    {
        _voteStrategy = new WikiVoteStrategy(configuration.ContendersCount, friend);
    }

    public virtual bool MakeDecision(Contender contender)
    {
        return _voteStrategy.Vote(contender);
    }

    public static int GetHappiness(Contender? contender, List<Contender> allContenders)
    {
        if (contender == null)
        {
            return 10;
        }

        allContenders.Sort();
        var decisionPosition = allContenders.IndexOf(contender);

        return decisionPosition < allContenders.Count / 2 ? 0 : decisionPosition;
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