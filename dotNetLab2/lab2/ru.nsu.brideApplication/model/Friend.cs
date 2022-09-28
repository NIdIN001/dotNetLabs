using Microsoft.Extensions.Hosting;

namespace dotNetLab2.lab2.ru.nsu.brideApplication.model;

public class Friend : IComparer<Contender>, IHostedService
{
    private readonly List<Contender> _watchedContender;

    public Friend()
    {
        _watchedContender = new List<Contender>();
    }

    public void AddWatched(Contender contender)
    {
        _watchedContender.Add(contender);
    }

    public virtual int GetTotalWatchedCount()
    {
        return _watchedContender.Count;
    }

    public void ClearWatchedList()
    {
        _watchedContender.Clear();
    }

    public int Compare(Contender? x, Contender? y)
    {
        if (x == null || y == null)
        {
            throw new Exception();
        }

        if (x.Attractiveness > y.Attractiveness)
        {
            return 1;
        }

        if (x.Attractiveness < y.Attractiveness)
        {
            return -1;
        }

        return 0;
    }

    public virtual bool IsBetterThenAllViewed(Contender candidate)
    {
        foreach (var contender in _watchedContender)
        {
            if (Compare(candidate, contender) != 1)
            {
                return false;
            }
        }

        return true;
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