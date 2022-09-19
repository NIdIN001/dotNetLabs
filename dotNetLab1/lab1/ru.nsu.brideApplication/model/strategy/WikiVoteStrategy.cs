namespace dotNetLab1.lab1.ru.nsu.brideApplication.model.strategy;

public class WikiVoteStrategy : IVoteStrategy
{
    private readonly int _skipFirst;

    private readonly List<Contender> _watchedContender;

    public WikiVoteStrategy(int contendersCount)
    {
        _skipFirst = (int)(contendersCount / Math.E);
        _watchedContender = new List<Contender>();
    }

    public bool Vote(Contender contender)
    {
        if (_watchedContender.Count < _skipFirst)
        {
            _watchedContender.Add(contender);
            return false;
        }

        _watchedContender.Add(contender);
        return IsBetterThenAllViewed(contender);
    }

    private bool IsBetterThenAllViewed(Contender contender)
    {
        Contender? best = _watchedContender.Find(contender1 => contender1.Attractiveness > contender.Attractiveness);
        //вот эта лямбда исполняет роль "подруги", которая сравнивает претендентов

        return best == null;
    }
}