namespace dotNetLab2.lab2.ru.nsu.brideApplication.util;

public class ContenderNameProvider
{
    private readonly List<string> _possibleNames;
    private readonly List<string> _possibleSurnames;

    public ContenderNameProvider(string pathToFirstNameFile, string pathToLastNameFile)
    {
        _possibleNames = new List<string>(File.ReadAllLines(pathToFirstNameFile));
        _possibleSurnames = new List<string>(File.ReadAllLines(pathToLastNameFile));
    }

    public string GetName()
    {
        return _possibleNames[RandomProvider.GetRandom().Next(_possibleNames.Count)];
    }

    public string GetSurname()
    {
        return _possibleSurnames[RandomProvider.GetRandom().Next(_possibleSurnames.Count)];
    }
}