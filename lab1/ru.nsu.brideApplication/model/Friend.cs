namespace dotNetLabs.lab1.ru.nsu.brideApplication.model;

// // на самом деле подруга это предикат который сравнивает претендентов
// public class Friend : IComparer<Contender>
// {
//     public int Compare(Contender? x, Contender? y)
//     {
//         if (x == null || y == null)
//         {
//             throw new Exception();
//         }
//
//         if (x.Attractiveness > y.Attractiveness)
//         {
//             return 1;
//         }
//
//         if (x.Attractiveness < y.Attractiveness)
//         {
//             return -1;
//         }
//
//         return 0;
//     }
// }

public class Friend
{
    public Contender ReturnBetter(Contender a, Contender b)
    {
        return a.Attractiveness > b.Attractiveness ? a : b;
    }
}