using dotNetLab2.lab2.ru.nsu.brideApplication.model.strategy;

namespace dotNetLab2.lab2.ru.nsu.brideApplication.model;

public class Princess
{
    private Friend _friend;
    private readonly IVoteStrategy _voteStrategy;

    public Princess(Friend friend, IVoteStrategy voteStrategy)
    {
        _friend = friend;
        _voteStrategy = voteStrategy;
    }

    public bool MakeDecision(Contender contender)
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
}