using dotNetLab2.lab2.ru.nsu.brideApplication.model;
using dotNetLab2.lab2.ru.nsu.brideApplication.model.strategy;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace dotNetLab2Test;

[TestClass]
public class StupidVoteStrategyTest
{
    [TestMethod]
    public void StupidStrategyTest()
    {
        var strategy = new StupidVoteStrategy();

        var result = strategy.Vote(new Contender("", "", 99));

        Assert.IsFalse(result);
    }
}