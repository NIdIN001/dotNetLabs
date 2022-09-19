namespace dotNetLab2.lab2.ru.nsu.brideApplication.model;

public class Friend : IComparer<Contender>
{
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
}