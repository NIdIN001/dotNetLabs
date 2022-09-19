namespace dotNetLab2.lab2.ru.nsu.brideApplication.model.strategy;

public class WikiVoteStrategy : IVoteStrategy
{
    private readonly int _skipFirst;

    private readonly List<Contender> _watchedContender;
    private readonly Friend _friend;

    public WikiVoteStrategy(int contendersCount, Friend friend)
    {
        _skipFirst = (int)(contendersCount / Math.E);
        _friend = friend;
        _watchedContender = new List<Contender>();
    }

    public bool Vote(Contender contender)
    {
        if (_watchedContender.Count < _skipFirst)
        {
            _watchedContender.Add(contender);
            return false;
        }

        var result = IsBetterThenAllViewed(contender);
        _watchedContender.Add(contender);
        return result;
    }

    private bool IsBetterThenAllViewed(Contender contender)
    {
        return IsContainsBetter(contender);
    }

    private bool IsContainsBetter(Contender candidate)
    {
        foreach (var contender in _watchedContender)
        {
            if (_friend.Compare(candidate, contender) == 1)
            {
                return true;
            }
        }

        return false;
    }
}