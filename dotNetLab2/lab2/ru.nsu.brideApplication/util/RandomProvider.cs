namespace dotNetLab2.lab2.ru.nsu.brideApplication.util;

public static class RandomProvider
{
    private static readonly Random Random = new();

    public static Random GetRandom()
    {
        return Random;
    }
}