using dotNetLabs.lab1.ru.nsu.brideApplication.model;

namespace dotNetLabs.lab1.ru.nsu.brideApplication.service;

public class ThroneRoom
{
    public Contender? ChooseHusband(Princess princess, Hall hall)
    {
        for (int i = 0; i < hall.GetContendersCount(); i++)
        {
            var contender = hall.GetByIndex(i);

            var isSelected = princess.MakeDecision(contender);
            if (isSelected)
            {
                return contender;
            }
        }

        return null;
    }
}