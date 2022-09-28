using dotNetLab2.lab2.ru.nsu.brideApplication.configuration;
using dotNetLab2.lab2.ru.nsu.brideApplication.service;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace dotNetLab2Test;

[TestClass]
public class HallTest
{
    [TestMethod]
    public void GetContendersCountTest()
    {
        var hall = CreateHall();

        var result = hall.GetContendersCount();

        Assert.AreEqual(100, result);
    }

    [TestMethod]
    public void FillTest()
    {
        var hall = CreateHall();

        hall.Fill();
        var result = hall.GetAllContenders().Count;

        Assert.AreEqual(100, result);
    }

    [TestMethod]
    public void GetByIndexTest()
    {
        var hall = CreateHall();

        hall.Fill();
        var contender1 = hall.GetByIndex(0);
        var contender2 = hall.GetByIndex(99);

        Assert.IsNotNull(contender1);
        Assert.IsNotNull(contender2);
    }

    private static Hall CreateHall()
    {
        var config = new ContenderConfiguration();
        config.ContendersCount = 100;
        var generator = new ContenderGeneratorService(config);
        return new Hall(generator, config);
    }
}