using dotNetLab2.lab2.ru.nsu.brideApplication.configuration;
using dotNetLab2.lab2.ru.nsu.brideApplication.model;

namespace dotNetLab2.lab2.ru.nsu.brideApplication.service;

public class Hall
{
    private readonly ContenderGeneratorService _contenderGeneratorService;
    private readonly ContenderConfiguration _contenderConfiguration;

    private readonly List<Contender> _allContenders;

    public Hall(ContenderGeneratorService contenderGenerator, ContenderConfiguration contenderConfiguration)
    {
        _contenderConfiguration = contenderConfiguration;
        _contenderGeneratorService = contenderGenerator;
        _allContenders = new List<Contender>();

        FillHall();
    }

    public Contender GetByIndex(int index)
    {
        return _allContenders[index];
    }

    public List<Contender> GetAllContenders()
    {
        return _allContenders;
    }

    public int GetContendersCount()
    {
        return _contenderConfiguration.ContendersCount;
    }

    private void FillHall()
    {
        while (_allContenders.Count < _contenderConfiguration.ContendersCount)
        {
            _allContenders.Add(_contenderGeneratorService.GenerateContender());
        }
    }
}