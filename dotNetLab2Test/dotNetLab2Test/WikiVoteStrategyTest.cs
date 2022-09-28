using dotNetLab2.lab2.ru.nsu.brideApplication.model;
using dotNetLab2.lab2.ru.nsu.brideApplication.model.strategy;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace dotNetLab2Test;

[TestClass]
public class WikiVoteStrategyTest
{
    [TestMethod]
    public void WikiVoteStrategy_skipFirstN_expectFalse()
    {
        var strategy = new WikiVoteStrategy(100, new Friend());

        var result = strategy.Vote(new Contender("", "", 100));

        Assert.IsFalse(result);
    }
    
    [TestMethod]
    public void WikiVoteStrategy_badHusband_expectFalse()
    {
        var strategy = new WikiVoteStrategy(100, new Friend());

        for (int i = 0; i < 37; i++)
        {
            strategy.Vote(new Contender("", "", 50));
        }

        var result = strategy.Vote(new Contender("", "", 32));

        Assert.IsFalse(result);
    }

    [TestMethod]
    public void WikiVoteStrategy_goodHusband_expectTrue()
    {
        var strategy = new WikiVoteStrategy(100, new Friend());

        for (int i = 0; i < 37; i++)
        {
            strategy.Vote(new Contender("", "", 1));
        }

        var result = strategy.Vote(new Contender("", "", 5));

        Assert.IsTrue(result);
    }
}