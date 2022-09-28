using dotNetLab2.lab2.ru.nsu.brideApplication.model;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace dotNetLab2Test;

[TestClass]
public class ContenderTest
{
    [TestMethod]
    public void ComparatorTest_compareToNull_expectBetter()
    {
        var contender = new Contender("", "", 1);

        var result = contender.CompareTo(null);

        Assert.AreEqual(1, result);
    }

    [TestMethod]
    public void ComparatorTest_compareWithMore_expectLess()
    {
        var contender = new Contender("", "", 1);
        var contender2 = new Contender("", "", 2);

        var result = contender.CompareTo(contender2);

        Assert.AreEqual(-1, result);
    }

    [TestMethod]
    public void ComparatorTest_compareWithLess_expectMore()
    {
        var contender = new Contender("", "", 5);
        var contender2 = new Contender("", "", 2);

        var result = contender.CompareTo(contender2);

        Assert.AreEqual(1, result);
    }

    [TestMethod]
    public void ComparatorTest_compareWithEqual_expectEqual()
    {
        var contender = new Contender("", "", 5);
        var contender2 = new Contender("", "", 5);

        var result = contender.CompareTo(contender2);

        Assert.AreEqual(0, result);
    }
}