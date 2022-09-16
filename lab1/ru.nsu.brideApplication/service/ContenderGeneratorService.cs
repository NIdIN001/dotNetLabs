using dotNetLabs.lab1.ru.nsu.brideApplication.model;
using dotNetLabs.lab1.ru.nsu.brideApplication.util;

namespace dotNetLabs.lab1.ru.nsu.brideApplication.service;

public class ContenderGeneratorService
{
    private readonly int _contenderCount;

    private readonly List<int> _possibleAttractiveness;

    public ContenderGeneratorService(int contendersCount)
    {
        _possibleAttractiveness = new List<int>();
        _contenderCount = contendersCount;

        FillPossibleAttractiveness();
    }

    public Contender GenerateContender()
    {
        var index = RandomProvider.GetRandom().Next(_possibleAttractiveness.Count);
        var attractiveness = _possibleAttractiveness[index];
        _possibleAttractiveness.RemoveAt(index);

        return new Contender(ContenderNameProvider.GetName(), ContenderNameProvider.GetSurname(), attractiveness);
    }

    private void FillPossibleAttractiveness()
    {
        for (int i = 0; i < _contenderCount; i++)
        {
            _possibleAttractiveness.Add(i + 1);
        }
    }
}