namespace dotNetLab1.lab1.ru.nsu.brideApplication.model;

public class Contender : IComparable<Contender>
{
    public string Name { get; }
    public string Surname { get; }
    public int Attractiveness { get; }

    public Contender(string name, string surname, int attractiveness)
    {
        Name = name;
        Surname = surname;
        Attractiveness = attractiveness;
    }

    public int CompareTo(Contender? other)
    {
        if (other == null)
        {
            return 1;
        }

        if (Attractiveness > other.Attractiveness)
        {
            return 1;
        }

        if (Attractiveness < other.Attractiveness)
        {
            return -1;
        }

        return 0;
    }
}