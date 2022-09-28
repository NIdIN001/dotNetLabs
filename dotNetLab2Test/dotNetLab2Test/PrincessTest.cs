using dotNetLab2.lab2.ru.nsu.brideApplication.configuration;
using dotNetLab2.lab2.ru.nsu.brideApplication.model;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;

namespace dotNetLab2Test;

[TestClass]
public class PrincessTest
{
    [TestMethod]
    public void MakeDecisionFalseTest()
    {
        var mockContendersConfig = new Mock<ContenderConfiguration>();
        var mockFriend = new Mock<Friend>();
        var princess = new Princess(mockFriend.Object, mockContendersConfig.Object);
        var contender = new Contender("", "", 1);

        mockFriend.Setup(s => s.IsBetterThenAllViewed(contender)).Returns(false);
        mockFriend.Setup(s => s.GetTotalWatchedCount()).Returns(0);

        var result = princess.MakeDecision(contender);
        Assert.IsFalse(result);
    }

    [TestMethod]
    public void MakeDecisionTrueTest()
    {
        var mockContendersConfig = new Mock<ContenderConfiguration>();
        var mockFriend = new Mock<Friend>();
        var princess = new Princess(mockFriend.Object, mockContendersConfig.Object);
        var contender = new Contender("", "", 1);

        mockFriend.Setup(s => s.IsBetterThenAllViewed(contender)).Returns(true);
        mockFriend.Setup(s => s.GetTotalWatchedCount()).Returns(0);
        mockContendersConfig.Setup(s => s.ContendersCount).Returns(100);

        var result = princess.MakeDecision(contender);
        Assert.IsTrue(result);
    }

    [TestMethod]
    public void GetHappinessTest()
    {
        Assert.AreEqual(10, Princess.GetHappiness(null, null));
    }
    
    [TestMethod]
    public void GetHappinessTest_wrongHusband_expectedZero()
    {
        var contenders = new List<Contender>();
        contenders.Add(new Contender("","", 97));
        contenders.Add(new Contender("","", 98));
        contenders.Add(new Contender("","", 99));
        contenders.Add(new Contender("","", 100));

        var result = Princess.GetHappiness(new Contender("", "", 1), contenders);
        Assert.AreEqual(0, result);
    }
    
    [TestMethod]
    public void GetHappinessTest_goodHusband_expectedMoreThenZero()
    {
        var contenders = new List<Contender>();
        var princessChoise = new Contender("", "", 100);
        contenders.Add(new Contender("","", 7));
        contenders.Add(new Contender("","", 8));
        contenders.Add(new Contender("","", 9));
        contenders.Add(new Contender("","", 10));
        contenders.Add(princessChoise);

        var result = Princess.GetHappiness(princessChoise, contenders);
        Assert.AreEqual(4, result);
    }
}