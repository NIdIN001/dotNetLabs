using dotNetLab2.lab2.ru.nsu.brideApplication.model;
using dotNetLab2.lab2.ru.nsu.brideApplication.util;

namespace dotNetLab2.lab2.ru.nsu.brideApplication.service;

public class ContenderGeneratorService
{
    private readonly int _contenderCount;

    private readonly List<int> _possibleAttractiveness;

    private readonly ContenderNameProvider _contenderNameProvider;

    public ContenderGeneratorService(int contendersCount, string firstnameFilePath, string lastnameFilePath)
    {
        _contenderNameProvider = new ContenderNameProvider(firstnameFilePath, lastnameFilePath);
        _possibleAttractiveness = new List<int>();
        _contenderCount = contendersCount;

        FillPossibleAttractiveness();
    }

    public Contender GenerateContender()
    {
        var index = RandomProvider.GetRandom().Next(_possibleAttractiveness.Count);
        var attractiveness = _possibleAttractiveness[index];
        _possibleAttractiveness.RemoveAt(index);

        return new Contender(_contenderNameProvider.GetName(), _contenderNameProvider.GetSurname(), attractiveness);
    }

    private void FillPossibleAttractiveness()
    {
        for (int i = 0; i < _contenderCount; i++)
        {
            _possibleAttractiveness.Add(i + 1);
        }
    }
}