namespace dotNetLab2.lab2.ru.nsu.brideApplication.model.strategy;

public class StupidVoteStrategy : IVoteStrategy
{
    public bool Vote(Contender contender)
    {
        return false;
    }
}