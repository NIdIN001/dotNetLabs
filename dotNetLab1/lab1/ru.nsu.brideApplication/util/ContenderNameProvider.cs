namespace dotNetLab1.lab1.ru.nsu.brideApplication.util;

public static class ContenderNameProvider
{
    private static List<string> _possibleNames = new List<string>
        { "Иван", "Петр", "Эдуард", "Станислав", "Илья" };

    private static List<string> _possibleSurnames = new List<string>
        { "Уточкин", "Петров", "Иванов", "Зайчиков", "Ляпунов" };

    public static string GetName()
    {
        return _possibleNames[RandomProvider.GetRandom().Next(_possibleNames.Count)];
    }

    public static string GetSurname()
    {
        return _possibleSurnames[RandomProvider.GetRandom().Next(_possibleSurnames.Count)];
    }
}