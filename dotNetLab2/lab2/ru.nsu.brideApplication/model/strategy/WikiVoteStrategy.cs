namespace dotNetLab2.lab2.ru.nsu.brideApplication.model.strategy;

public class WikiVoteStrategy : IVoteStrategy
{
    private readonly int _skipFirst;
    private readonly Friend _friend;

    public WikiVoteStrategy(int contendersCount, Friend friend)
    {
        _skipFirst = (int)(contendersCount / Math.E);
        _friend = friend;
    }

    public bool Vote(Contender contender)
    {
        if (_friend.GetTotalWatchedCount() < _skipFirst)
        {
            _friend.AddWatched(contender);
            return false;
        }

        var result = _friend.IsBetterThenAllViewed(contender);
        _friend.AddWatched(contender);
        return result;
    }
}